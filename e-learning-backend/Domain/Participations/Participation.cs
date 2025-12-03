using e_learning_backend.Domain.Classes;
using e_learning_backend.Domain.Courses;
using e_learning_backend.Domain.Users;

namespace e_learning_backend.Domain.Participations;

public class Participation
{
    public Guid UserId { get; set; }
    public User User { get; set; }
    
    public Guid CourseVariantId { get; set; }
    public CourseVariant CourseVariant { get; set; }
    
    public Guid? ReviewId { get;set; }
    public Review? Review { get; set; }
    
    public bool Notifications { get; set; } // For a teacher
    
    private readonly HashSet<Class> _classes = new();
    public IReadOnlyCollection<Class> Classes => _classes;
    
    protected Participation() { }
    
    public Participation(User user, CourseVariant courseVariant, bool notifications = false)
    {
        User = user ?? throw new ArgumentNullException(nameof(user));
        CourseVariant = courseVariant ?? throw new ArgumentNullException(nameof(courseVariant));
        UserId = user.Id;
        CourseVariantId = courseVariant.Id;
        Notifications = notifications;

        // Add this participation to both collections
        user.AddParticipation(this);
        courseVariant.AddParticipation(this);
    }
    
    public void TurnOnNotifications()
    {
        Notifications = true;
    }
    
    public void TurnOffNotifications()
    {
        Notifications = false;
    }
    
    public void AddReview(int starsNumber, string content)
    {
        if (Review != null)
        {
            throw new InvalidOperationException("Participation already has a review.");
        }

        Review = new Review(starsNumber, content, this);
        ReviewId = Review.Id;
    }
}