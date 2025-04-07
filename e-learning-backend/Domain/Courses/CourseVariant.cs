using e_learning_backend.Domain.Courses.ValueObjects;

namespace e_learning_backend.Domain.Courses;

/// <summary>
///     Represents a specific variant of a course, defined by level, language, and rate.
/// </summary>
public class CourseVariant
{
    public Guid Id { get; private set; }
    public CourseLevel Level { get; private set; }
    public CourseRate Rate { get; private set; }
    public CourseLanguage Language { get; private set; }

    public CourseVariant() { }

    public CourseVariant(CourseLevel level, CourseRate rate, CourseLanguage language)
    {
        Id = Guid.NewGuid();
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
}