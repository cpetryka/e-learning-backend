using e_learning_backend.Domain.Courses.ValueObjects;

namespace e_learning_backend.Domain.Courses;

public class CourseVariant
{
    internal Guid Id { get; set; }
    internal CourseLevel Level { get; set; }
    internal CourseRate Rate { get; set; }
    internal CourseLanguage Language { get; set; }

    private CourseVariant() { }

    public CourseVariant(CourseLevel level, CourseRate rate, CourseLanguage language)
    {
        Id = Guid.NewGuid();
        Level = level ?? throw new ArgumentNullException(nameof(level));
        Rate = rate ?? throw new ArgumentNullException(nameof(rate));
        Language = language ?? throw new ArgumentNullException(nameof(language));
    }
}