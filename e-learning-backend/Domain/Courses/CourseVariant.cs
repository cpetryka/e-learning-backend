using e_learning_backend.Domain.Courses.ValueObjects;
using e_learning_backend.Domain.Participations;

namespace e_learning_backend.Domain.Courses;

/// <summary>
///     Represents a specific variant of a course, defined by level, language, and rate.
/// </summary>
public class CourseVariant
{
    public Guid Id { get; private set; }
    public CourseLevel Level { get; private set; }
    public CourseRate Rate { get; set; }
    public CourseLanguage Language { get; private set; }
    
    public Guid CourseId { get; private set; }
    public Course Course { get; private set; }
    
    private readonly HashSet<Participation> _participations = new();
    public IReadOnlyCollection<Participation> Participations => _participations;

    public CourseVariant() { }

    public CourseVariant(Course course, CourseLevel level, CourseRate rate, CourseLanguage language)
    {
        Id = Guid.NewGuid();
        Course = course ?? throw new ArgumentNullException(nameof(course));
        Level = level ?? throw new ArgumentNullException(nameof(level));
        Rate = rate ?? throw new ArgumentNullException(nameof(rate));
        Language = language ?? throw new ArgumentNullException(nameof(language));
    }

    /// <summary>
    ///     Updates the rate of the course variant.
    /// </summary>
    /// <param name="newRate">The new rate to assign.</param>
    /// <exception cref="ArgumentNullException">Thrown when the provided rate is null.</exception>
    public void UpdateRate(CourseRate newRate)
    {
        Rate = newRate ?? throw new ArgumentNullException(nameof(newRate));
    }
    
    public void AddParticipation(Participation participation)
    {
        if (participation == null)
        {
            throw new ArgumentNullException(nameof(participation));
        }
        
        _participations.Add(participation);
    }
    
    public void RemoveParticipation(Participation participation)
    {
        if (participation == null)
        {
            throw new ArgumentNullException(nameof(participation));
        }

        if (!_participations.Contains(participation))
        {
            throw new InvalidOperationException("Participation does not exist for this course variant.");
        }

        _participations.Remove(participation);
    }
}