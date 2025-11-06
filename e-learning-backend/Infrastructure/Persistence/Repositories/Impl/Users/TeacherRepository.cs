using e_learning_backend.Domain.ExercisesAndMaterials.ValueObjects;
using e_learning_backend.Domain.Users;
using e_learning_backend.Domain.Users.ValueObjects;
using e_learning_backend.Infrastructure.Api.DTO;
using e_learning_backend.Infrastructure.Persistence.DatabaseContexts;
using Microsoft.EntityFrameworkCore;

namespace e_learning_backend.Infrastructure.Persistence.Repositories.Impl;

public class TeacherRepository : ITeacherRepository
{
    private readonly ApplicationContext _context;

    public TeacherRepository(ApplicationContext context)
    {
        _context = context;
    }

    public async Task<User?> GetTeacherWithDetailsAsync(Guid teacherId)
    {
        return await _context.Users
            .Include(u => u.ConductedCourses)
            .Where(u => u.Id == teacherId)
            .Where(u => u.Roles.Any(r => r.RoleName == Role.Teacher.RoleName))
            .FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<TeacherReviewDTO>> GetTeacherReviews(Guid teacherId)
    {
        return await _context.Participations
            .Where(p => p.Course.TeacherId == teacherId && p.Review != null)
            .Select(p => new TeacherReviewDTO
            {
                ReviewId = p.Review.Id,
                ReviewerName = p.User.Name,
                ReviewerSurname = p.User.Surname,
                StarsNumber = p.Review!.StarsNumber,
                Content = p.Review.Content
            })
            .ToListAsync();
    }

    public async Task<List<TeacherAvailabilityDTO>> GetTeacherAvailabilityAsync(Guid teacherId)
    {
        var teacherAvailability = await _context.Availabilities
            .Include(a => a.TimeSlots)
            .Where(a => a.TeacherId == teacherId)
            .ToListAsync();

        var today = DateTime.Today;
        var currentDayOfWeek = (int)today.DayOfWeek;
        var mondayOffset = currentDayOfWeek == 0 ? -6 : -(currentDayOfWeek - 1);
        var startDate = DateOnly.FromDateTime(today.AddDays(mondayOffset));

        var daysRange = Enumerable.Range(0, 35)
            .Select(offset => startDate.AddDays(offset))
            .ToList();

        var availabilityDtos = daysRange.Select(day =>
        {
            // Dni przed dzisiejszym -> puste
            if (day < DateOnly.FromDateTime(today))
            {
                return new TeacherAvailabilityDTO
                {
                    Day = day,
                    Timeslots = new List<TeacherAvailabilityDTO.TimeslotDTO>()
                };
            }

            var dayAvailability =
                teacherAvailability.FirstOrDefault(a => DateOnly.FromDateTime(a.Date) == day);

            if (dayAvailability == null)
            {
                return new TeacherAvailabilityDTO
                {
                    Day = day,
                    Timeslots = new List<TeacherAvailabilityDTO.TimeslotDTO>()
                };
            }

            // Timesloty dla dnia aktualnego - filtrujemy te, które już minęły
            var timeslots = dayAvailability.TimeSlots
                .OrderBy(t => t.StartTime)
                .Select(t => new TeacherAvailabilityDTO.TimeslotDTO
                {
                    TimeFrom = TimeOnly.FromDateTime(t.StartTime),
                    TimeUntil = TimeOnly.FromDateTime(t.EndTime)
                })
                .ToList();

            // Jeśli to dzisiejszy dzień, odfiltruj przeszłe sloty
            if (day == DateOnly.FromDateTime(today))
            {
                var currentTime = DateTime.Now.TimeOfDay;
                timeslots = timeslots
                    .Where(ts => ts.TimeUntil > TimeOnly.FromTimeSpan(currentTime))
                    .ToList();
            }

            return new TeacherAvailabilityDTO
            {
                Day = day,
                Timeslots = timeslots
            };
        }).ToList();

        return availabilityDtos;
    }

    public async Task<IEnumerable<StudentBriefDTO>> GetStudentsByTeacherIdAsync(Guid teacherId)
    {
        return await _context.Participations
            .Where(p => p.Course.TeacherId == teacherId)
            .Select(p => p.User)
            .Distinct()
            .Select(s => new StudentBriefDTO
            {
                Id = s.Id,
                Name = s.Name,
                Surname = s.Surname
            })
            .ToListAsync();
    }

    public async Task<IEnumerable<CourseBriefDTO>> GetCoursesByTeacherIdAsync(Guid teacherId)
    {
        return await _context.Courses
            .Where(c => c.TeacherId == teacherId)
            .Distinct()
            .Select(c => new CourseBriefDTO
            {
                Id = c.Id,
                Name = c.Name
            })
            .ToListAsync();
    }

    public async Task<IEnumerable<StudentBriefDTO>> GetStudentsByTeacherIdAndCourseIdAsync(Guid teacherId,
        Guid courseId)
    {
        return await _context.Participations
            .Where(p => p.Course.TeacherId == teacherId && p.CourseId == courseId)
            .Select(p => p.User)
            .Distinct()
            .Select(s => new StudentBriefDTO
            {
                Id = s.Id,
                Name = s.Name,
                Surname = s.Surname
            })
            .ToListAsync();
    }

    public async Task<IEnumerable<CourseBriefDTO>> GetCoursesByTeacherIdAndStudentIdAsync(Guid teacherId,
        Guid studentId)
    {
        return await _context.Participations
            .Where(p => p.Course.TeacherId == teacherId && p.UserId == studentId)
            .Select(p => p.Course)
            .Distinct()
            .Select(c => new CourseBriefDTO
            {
                Id = c.Id,
                Name = c.Name
            })
            .ToListAsync();
    }


    public async Task<IEnumerable<ClassWithStudentsDTO>> GetClassesWithStudentsByTeacherIdAsync(Guid teacherId)
    {
        // 1) Unikalne kursy prowadzone przez nauczyciela (bez kolekcji -> Distinct bez problemu)
        var courses = await _context.Courses
            .AsNoTracking()
            .Where(c => c.TeacherId == teacherId)
            .Select(c => new { c.Id, c.Name })
            .ToListAsync();

        var courseIds = courses.Select(c => c.Id).ToList();

        
        var studentsFlat = await _context.Participations
            .AsNoTracking()
            .Where(p => courseIds.Contains(p.CourseId))
            .Select(p => new
            {
                p.CourseId,
                UserId = p.User.Id,
                p.User.Name,
                p.User.Surname
            })
            .ToListAsync();

       
        var studentsByCourse = studentsFlat
            .GroupBy(x => x.CourseId)
            .ToDictionary(
                g => g.Key,
                g => g.GroupBy(x => x.UserId)
                    .Select(g2 => new StudentBriefDTO
                    {
                        Id = g2.Key,
                        Name = g2.First().Name ?? string.Empty,
                        Surname = g2.First().Surname ?? string.Empty
                    })
                    .ToList()
            );

       
        var result = courses.Select(c => new ClassWithStudentsDTO
            {
                CourseId = c.Id,                        
                CourseName = c.Name ?? string.Empty,
                Students = studentsByCourse.TryGetValue(c.Id, out var list)
                    ? list
                    : new List<StudentBriefDTO>()
            })
            .ToList();

        return result;
    }

    public async Task<IEnumerable<TeacherUpcomingClass>> GetUpcomingClassesAsync(Guid teacherId,
        DateOnly start, DateOnly end)
    {
        return await _context.Classes
            .Include(c => c.Participation)
            .ThenInclude(c => c.Course)
            .Include(c => c.Participation)
            .ThenInclude(c => c.User)
            .Where(c => c.Participation.Course.TeacherId == teacherId &&
                        DateOnly.FromDateTime(c.StartTime) >= start &&
                        DateOnly.FromDateTime(c.StartTime.AddHours(1)) <= end)
            .Select(c => new TeacherUpcomingClass
            {
                ClassId = c.Id,
                StudentId = c.UserId,
                StudentName = c.Participation.User.Name + " " + c.Participation.User.Surname,
                CourseId = c.Participation.Course.Id,
                CourseName = c.Participation.Course.Name,
                ClassDate = DateOnly.FromDateTime(c.StartTime),
                ClassStartTime = TimeOnly.FromDateTime(c.StartTime),
                ClassEndTime = TimeOnly.FromDateTime(c.StartTime.AddHours(1))
            })
            .ToListAsync();
        
    }
    
    public async Task<IEnumerable<ExerciseBriefDTO>> GetExercisesToGradeAsync(Guid teacherId)
    {
        return await _context.Exercises
            .Include(e => e.Class)
            .ThenInclude(c => c.Participation)
            .ThenInclude(p => p.Course)
            .Where(e => e.Class.Participation.Course.TeacherId == teacherId &&
                        e.Status == ExerciseStatus.Submitted)
            .Select(e => new ExerciseBriefDTO
            {
                Id = e.Id,
                CourseId = e.Class.Participation.Course.Id,
                CourseName = e.Class.Participation.Course.Name,
                ClassStartTime = e.Class.StartTime,
                ExerciseStatus = e.Status.ToString()
            })
            .ToListAsync();
    }
}