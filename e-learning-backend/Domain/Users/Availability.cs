namespace e_learning_backend.Domain.Users;

public class Availability
{
    public Guid Id { get; private set; }
    public DateTime Date { get; private set; }
    
    public Guid TeacherId { get; private set; }
    public User Teacher { get; private set; }
    
    private readonly HashSet<TimeSlot> _timeSlots = new();
    public IReadOnlyCollection<TimeSlot> TimeSlots => _timeSlots;
    
    protected Availability() { }
    
    public Availability(Guid id, DateTime date, User teacher)
    {
        Id = id;
        Date = date;
        Teacher = teacher ?? throw new ArgumentNullException(nameof(teacher));
        TeacherId = teacher.Id;
    }
    
    public Availability(DateTime date, User teacher) : this(Guid.NewGuid(), date, teacher) { }
    
    public void AddTimeSlot(TimeSlot timeSlot)
    {
        if (timeSlot == null)
        {
            throw new ArgumentNullException(nameof(timeSlot));
        }
        
        if (timeSlot.Availability != null && timeSlot.Availability != this)
        {
            throw new InvalidOperationException("Time slot is already associated with an availability.");
        }
        
        _timeSlots.Add(timeSlot);
        timeSlot.Availability = this;
    }
    
    public void RemoveTimeSlot(TimeSlot timeSlot)
    {
        if (timeSlot == null)
        {
            throw new ArgumentNullException(nameof(timeSlot));
        }
        
        if (!_timeSlots.Remove(timeSlot))
        {
            throw new InvalidOperationException("Time slot is not associated with this availability.");
        }
        
        timeSlot.Availability = null;
    }
    
    public void RemoveAllTimeSlots() 
    {
        foreach (var timeSlot in _timeSlots.ToList())
        {
            RemoveTimeSlot(timeSlot);
        }
    }
}