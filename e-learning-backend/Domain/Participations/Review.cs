using e_learning_backend.Domain.Courses;

namespace e_learning_backend.Domain.Participations;

public class Review
{
    public Guid Id { get; set; }
    public int StarsNumber { get; set; }
    public String Content { get; set; }
    
    public Participation Participation { get; set; }

    protected Review() { }
    
    public Review(Guid id, int starsNumber, string content, Participation participation)
    {
        Id = id;
        StarsNumber = starsNumber;
        Content = content;
        Participation = participation ?? throw new ArgumentNullException(nameof(participation));
    }
    
    public Review(int starsNumber, string content, Participation participation)
    {
        Id = Guid.NewGuid();
        StarsNumber = starsNumber;
        Content = content;
        Participation = participation ?? throw new ArgumentNullException(nameof(participation));
    }
}