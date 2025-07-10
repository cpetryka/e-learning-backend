using e_learning_backend.Domain.Courses;
using e_learning_backend.Domain.Users;

namespace e_learning_backend.Domain.Participations;

public class Participation
{
    public Guid UserId { get; set; }
    public User User { get; set; }
    
    public Guid CourseId { get;set; }
    public Course Course { get; set; }
    
    public bool Notifications { get; set; } // For a teacher
    
    protected Participation() { }
    
    public Participation(User user, Course course, bool notifications = false)
    {
        User = user ?? throw new ArgumentNullException(nameof(user));
        Course = course ?? throw new ArgumentNullException(nameof(course));
        UserId = user.Id;
        CourseId = course.Id;
        Notifications = notifications;

        // Add this participation to both collections
        user.AddParticipation(this);
        course.AddParticipation(this);
    }
    
    public void TurnOnNotifications()
    {
        Notifications = true;
    }
    
    public void TurnOffNotifications()
    {
        Notifications = false;
    }
}