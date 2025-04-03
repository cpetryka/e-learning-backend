namespace e_learning_backend.Domain.Courses.ValueObjects;

public class CourseLevel
{
    private string Name { get; }

    private CourseLevel(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("Level cannot be empty.");
        }

        Name = name;
    }

    public static CourseLevel Create(string name) => new CourseLevel(name);
}