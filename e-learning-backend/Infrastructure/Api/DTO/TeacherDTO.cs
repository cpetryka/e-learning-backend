namespace e_learning_backend.Infrastructure.Api.DTO;

public class TeacherDTO
{
    public string Name { get; set; } = default!;
    public string Surname { get; set; } = default!;
    public string? Description { get; set; }
    public List<CourseBriefDTO> CoursesBrief { get; set; } = new();
    public List<AvailabilityDTO> Availability { get; set; } = new();

    public class CourseBriefDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = default!;
    }

    public class AvailabilityDTO
    {
        public DateOnly Day { get; set; }
        public List<TimeslotDTO> Timeslots { get; set; } = new();
    }

    public class TimeslotDTO
    {
        public TimeOnly TimeFrom { get; set; }
        public TimeOnly TimeUntil { get; set; }
    }
}