namespace e_learning_backend.Domain.Courses;

/// <summary>
///     Represents a language in which a course can be conducted.
/// </summary>
public class CourseLanguage
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }

    private CourseLanguage() { }

    public CourseLanguage(Guid id, string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("Language cannot be empty.", nameof(name));
        }

        Id = id;
        Name = name;
    }

    public CourseLanguage(string name) : this(Guid.NewGuid(), name) { }
}