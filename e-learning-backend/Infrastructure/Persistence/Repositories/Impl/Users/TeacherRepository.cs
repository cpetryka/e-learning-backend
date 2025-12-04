using System.Text.Json;
﻿using e_learning_backend.Domain.ExercisesAndMaterials.ValueObjects;
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
    private class TeacherAvailabilityRow
    {
        public DateOnly Day { get; set; }
        public string Timeslots { get; set; } = "[]";
    }
    private class RawTimeslot
    {
        public string TimeFrom { get; set; } = default!;
        public string TimeUntil { get; set; } = default!;
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
            .Include(p => p.CourseVariant)
            .ThenInclude(cv => cv.Course)
            .Where(p => p.CourseVariant.Course.TeacherId == teacherId && p.Review != null)
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



    // public async Task<List<TeacherAvailabilityDTO>> GetTeacherAvailabilityAsync(Guid teacherId)
    // {
    //     var teacherAvailability = await _context.Availabilities
    //         .Include(a => a.TimeSlots)
    //         .Where(a => a.TeacherId == teacherId)
    //         .ToListAsync();
    //
    //     var today = DateTime.Today;
    //     var currentDayOfWeek = (int)today.DayOfWeek;
    //     var mondayOffset = currentDayOfWeek == 0 ? -6 : -(currentDayOfWeek - 1);
    //     var startDate = DateOnly.FromDateTime(today.AddDays(mondayOffset));
    //
    //     var daysRange = Enumerable.Range(0, 35)
    //         .Select(offset => startDate.AddDays(offset))
    //         .ToList();
    //
    //     var availabilityDtos = daysRange.Select(day =>
    //     {
    //         // Dni przed dzisiejszym -> puste
    //         if (day < DateOnly.FromDateTime(today))
    //         {
    //             return new TeacherAvailabilityDTO
    //             {
    //                 Day = day,
    //                 Timeslots = new List<TeacherAvailabilityDTO.TimeslotDTO>()
    //             };
    //         }
    //
    //         var dayAvailability =
    //             teacherAvailability.FirstOrDefault(a => DateOnly.FromDateTime(a.Date) == day);
    //
    //         if (dayAvailability == null)
    //         {
    //             return new TeacherAvailabilityDTO
    //             {
    //                 Day = day,
    //                 Timeslots = new List<TeacherAvailabilityDTO.TimeslotDTO>()
    //             };
    //         }
    //
    //         // Timesloty dla dnia aktualnego - filtrujemy te, które już minęły
    //         var timeslots = dayAvailability.TimeSlots
    //             .OrderBy(t => t.StartTime)
    //             .Select(t => new TeacherAvailabilityDTO.TimeslotDTO
    //             {
    //                 TimeFrom = TimeOnly.FromDateTime(t.StartTime),
    //                 TimeUntil = TimeOnly.FromDateTime(t.EndTime)
    //             })
    //             .ToList();
    //
    //         // Jeśli to dzisiejszy dzień, odfiltruj przeszłe sloty
    //         if (day == DateOnly.FromDateTime(today))
    //         {
    //             var currentTime = DateTime.Now.TimeOfDay;
    //             timeslots = timeslots
    //                 .Where(ts => ts.TimeUntil > TimeOnly.FromTimeSpan(currentTime))
    //                 .ToList();
    //         }
    //
    //         return new TeacherAvailabilityDTO
    //         {
    //             Day = day,
    //             Timeslots = timeslots
    //         };
    //     }).ToList();
    //
    //     return availabilityDtos;
    // }
    
    public async Task<List<TeacherAvailabilityDTO>> GetTeacherAvailabilityAsync(Guid teacherId)
    {
        var rows = await _context.Database
            .SqlQueryRaw<TeacherAvailabilityRow>(
                """
                SELECT
                    "Day",
                    "Timeslots"
                FROM get_teacher_availability({0})
                """,
                teacherId
            )
            .ToListAsync();

        var jsonOptions = new JsonSerializerOptions
        {
           
            PropertyNameCaseInsensitive = true 
        };

        var result = rows.Select(r =>
        {
           
            var raw = JsonSerializer.Deserialize<List<RawTimeslot>>(r.Timeslots ?? "[]", jsonOptions) ?? new();


            var slots = raw
                .Select(ts => new TeacherAvailabilityDTO.TimeslotDTO
                {
                    TimeFrom = TimeOnly.Parse(ts.TimeFrom), 
                    TimeUntil = TimeOnly.Parse(ts.TimeUntil)
                })
               
                .DistinctBy(s => (s.TimeFrom, s.TimeUntil))
                .OrderBy(s => s.TimeFrom)
                .ToList();

            return new TeacherAvailabilityDTO
            {
                Day = r.Day,
                Timeslots = slots
            };
        }).ToList();

        return result;
        
    }

    public async Task<IEnumerable<StudentBriefDTO>> GetStudentsByTeacherIdAsync(Guid teacherId)
    {
        return await _context.Participations
            .Include(p => p.CourseVariant)
            .ThenInclude(cv => cv.Course)
            .Where(p => p.CourseVariant.Course.TeacherId == teacherId)
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
            .Include(p => p.CourseVariant)
            .ThenInclude(cv => cv.Course)
            .Where(p => p.CourseVariant.Course.TeacherId == teacherId && p.CourseVariant.CourseId == courseId)
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
            .Include(p => p.CourseVariant)
            .ThenInclude(cv => cv.Course)
            .Where(p => p.CourseVariant.Course.TeacherId == teacherId && p.UserId == studentId)
            .Select(p => p.CourseVariant.Course)
            .Distinct()
            .Select(c => new CourseBriefDTO
            {
                Id = c.Id,
                Name = c.Name
            })
            .ToListAsync();
    }

    public async Task<IEnumerable<ExerciseDTO>> GetExercisesByTeacherIdAndStudentIdAsync(
        Guid teacherId, Guid studentId, Guid? courseId)
    {
        return await _context.Exercises
            .Include(e => e.Class)
                .ThenInclude(c => c.Participation)
                    .ThenInclude(p => p.CourseVariant)
                        .ThenInclude(cv => cv.Course)
            .Where(e => e.Class.Participation.CourseVariant.Course.TeacherId == teacherId &&
                        e.Class.Participation.UserId == studentId)
            .Where(e => courseId == null || e.Class.Participation.CourseVariant.CourseId == courseId)
            .Select(e => new ExerciseDTO()
            {
                Id = e.Id,
                Name = e.Class.Participation.CourseVariant.Course.Name + " [" + e.Class.StartTime.ToString("yyyy-MM-dd") + "]",
                Completed = e.Status == ExerciseStatus.Graded || e.Status == ExerciseStatus.Submitted,
                CourseName = e.Class.Participation.CourseVariant.Course.Name,
                Status = e.Status.ToString(),
                Graded = e.Grade != null,
                Grade = e.Grade,
                Comments = e.Comment ?? ""
            })
            .ToListAsync();
    }

    public async Task<IEnumerable<QuizSummaryDTO>> GetQuizzesByTeacherIdAndStudentIdAsync(
        Guid teacherId, Guid studentId, Guid? courseId)
    {
        return await _context.Quizzes
            .Include(e => e.Class)
                .ThenInclude(c => c.Participation)
                    .ThenInclude(p => p.CourseVariant)
                        .ThenInclude(p => p.Course)
            .Where(e => e.Class.Participation.CourseVariant.Course.TeacherId == teacherId &&
                        e.Class.Participation.UserId == studentId)
            .Where(e => courseId == null || e.Class.Participation.CourseVariant.CourseId == courseId)
            .Select(e => new QuizSummaryDTO
            {
                Id = e.Id,
                Name = e.Title,
                Completed = e.Score != null,
                CourseName = e.Class.Participation.CourseVariant.Course.Name,
                Type = "quiz"
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
            .Include(p => p.CourseVariant)
            .ThenInclude(cv => cv.Course)
            .AsNoTracking()
            .Where(p => courseIds.Contains(p.CourseVariant.CourseId))
            .Select(p => new
            {
                p.CourseVariant.CourseId,
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
            .ThenInclude(p => p.CourseVariant)
            .ThenInclude(c => c.Course)
            .Include(c => c.Participation)
            .ThenInclude(c => c.User)
            .Where(c => c.Participation.CourseVariant.Course.TeacherId == teacherId &&
                        DateOnly.FromDateTime(c.StartTime) >= start &&
                        DateOnly.FromDateTime(c.StartTime.AddHours(1)) <= end)
            .Select(c => new TeacherUpcomingClass
            {
                ClassId = c.Id,
                StudentId = c.UserId,
                StudentName = c.Participation.User.Name + " " + c.Participation.User.Surname,
                CourseId = c.Participation.CourseVariant.Course.Id,
                CourseName = c.Participation.CourseVariant.Course.Name,
                ClassDate = DateOnly.FromDateTime(c.StartTime),
                ClassStartTime = TimeOnly.FromDateTime(c.StartTime),
                ClassEndTime = TimeOnly.FromDateTime(c.StartTime.AddHours(1))
            })
            .ToListAsync();
        
    }
    
    public async Task<IEnumerable<ExerciseBriefDTO>> GetExercisesToGradeAsync(
        Guid teacherId, List<Guid>? courseIds = null, List<Guid>? studentIds = null)
    {
        return await _context.Exercises
            .Include(e => e.Class)
            .ThenInclude(c => c.Participation)
            .ThenInclude(p => p.CourseVariant)
            .ThenInclude(p => p.Course)
            .Where(e => e.Class.Participation.CourseVariant.Course.TeacherId == teacherId &&
                        e.Status == ExerciseStatus.Submitted)
            .Where(e => courseIds == null || courseIds.Count == 0 || 
                        courseIds.Contains(e.Class.Participation.CourseVariant.CourseId))
            .Where(e => studentIds == null || studentIds.Count == 0 || 
                        studentIds.Contains(e.Class.Participation.UserId))
            .Select(e => new ExerciseBriefDTO
            {
                Id = e.Id,
                CourseId = e.Class.Participation.CourseVariant.Course.Id,
                CourseName = e.Class.Participation.CourseVariant.Course.Name,
                ClassStartTime = e.Class.StartTime,
                ExerciseStatus = e.Status.ToString()
            })
            .ToListAsync();
    }
    
    public async Task<IEnumerable<GetExerciseDTO>> GetAllExercisesByTeacherIdAsync(Guid teacherId, Guid? courseId, Guid? studentId)
    {
        return await _context.Exercises
            .Include(e => e.Class)
            .ThenInclude(c => c.Participation)
            .ThenInclude(p => p.CourseVariant)
            .ThenInclude(p => p.Course)
            .Include(e => e.Class)
            .ThenInclude(c => c.Participation)
            .ThenInclude(p => p.User)
            .Include(e => e.ExerciseResources)
            .ThenInclude(e => e.File)
            .Where(e => e.Class.Participation.CourseVariant.Course.TeacherId == teacherId)
            .Where(e => courseId == null || e.Class.Participation.CourseVariant.CourseId == courseId)
            .Where(e => studentId == null || e.Class.Participation.UserId == studentId)
            .Select(e => new GetExerciseDTO()
            {
                Id = e.Id,
                Name = e.Class.Participation.CourseVariant.Course.Name + " [" + e.Class.StartTime.ToString("yyyy-MM-dd") + "] - " + e.Class.Participation.User.Name + " " + e.Class.Participation.User.Surname,
                CourseName = e.Class.Participation.CourseVariant.Course.Name,
                Status = e.Status.ToString(),
                Graded = e.Grade != null,
                Grade = e.Grade,
                Comments = e.Comment ?? "",
                Instruction = e.Instruction ?? "",
                Date = e.Class.StartTime,
                Files = e.ExerciseResources.Select(er => new GetExerciseResourceDTO()
                {
                    Id = er.FileId,
                    Name = er.File.Name,
                    Path = er.File.Path,
                    Type = er.Type.ToString().ToLower(),
                    UploadDate = er.File.AddedAt
                }).ToList()
            })
            .ToListAsync();
    }
}