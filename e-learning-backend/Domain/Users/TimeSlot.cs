using e_learning_backend.Domain.Participations;

namespace e_learning_backend.Domain.Users;

public class TimeSlot
{
    public Guid Id { get; private set; }
    public DateTime StartTime { get; private set; }
    public DateTime EndTime { get; private set; }
    
    public Guid AvailabilityId { get; private set; }
    public Availability Availability { get; set; }
    
    protected TimeSlot() { }
    
    public TimeSlot(Guid id, DateTime startTime, DateTime endTime, Availability availability)
    {
        if (startTime > endTime)
        {
            throw new ArgumentException("Start time must be before end time.");
        }
        
        Id = id;
        StartTime = startTime;
        EndTime = endTime;
        Availability = availability ?? throw new ArgumentNullException(nameof(availability));
    }
    
    public TimeSlot(DateTime startTime, DateTime endTime, Availability availability) 
        : this(Guid.NewGuid(), startTime, endTime, availability) {}
}