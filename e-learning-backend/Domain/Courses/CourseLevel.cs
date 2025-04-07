namespace e_learning_backend.Domain.Courses;

/// <summary>
///     Represents a level of difficulty or advancement for a course.
/// </summary>
public class CourseLevel
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }

    private CourseLevel() { }

    public CourseLevel(Guid id, string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("Level cannot be empty.", nameof(name));
        }

        Id = id;
        Name = name;
    }

    public CourseLevel(string name) : this(Guid.NewGuid(), name) { }
}
