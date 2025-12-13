namespace e_learning_backend.Infrastructure.Api.DTO;

public class AddDayAvailabilityDTO
{
    public string Day { get; set; } = string.Empty;
    public List<TimeslotDTO> Timeslots { get; set; } = new();
    
    public class TimeslotDTO
    {
        public string TimeFrom { get; set; } = string.Empty;
        public string TimeUntil { get; set; } = string.Empty;
    }
}

