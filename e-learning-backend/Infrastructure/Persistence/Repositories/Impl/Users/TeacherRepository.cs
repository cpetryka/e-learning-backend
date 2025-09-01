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

        var dayAvailability = teacherAvailability.FirstOrDefault(a => DateOnly.FromDateTime(a.Date) == day);

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


}