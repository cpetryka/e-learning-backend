namespace e_learning_backend.Domain.Classes.ValueObjects;
/// <summary>
///    Represents a class status, such as Canceled, Scheduled, During, Done 
/// </summary>
public class ClassStatus
{
    public Guid Id { get; private set; }
    public string Status { get; private set; }
    public ClassStatus() { }
    public ClassStatus(Guid id, string status)
    {
        setId(id);
        setStatus(status);
    }
    
    public void setId(Guid id)
    {
        Id = id;
    }
    public void setStatus(string status)
    {
        if (string.IsNullOrWhiteSpace(status))
        {
            throw new ArgumentException("Class status cannot be empty.", nameof(status));
        }
        Status = status;
    }

    public string getStatus()
    {
        return Status;
    }
    
    public Guid getId()
    {
        return Id;
    }

}