namespace e_learning_backend.Infrastructure.Api.DTO;

public class TeacherAvailabilityDTO
{
    public DateOnly Day { get; set; }
    public List<TimeslotDTO> Timeslots { get; set; } = new();
    
    public class TimeslotDTO
    {
        public TimeOnly TimeFrom { get; set; }
        public TimeOnly TimeUntil { get; set; }
    }

}

