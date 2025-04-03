namespace e_learning_backend.Domain.Courses.ValueObjects;

public class CourseLanguage
{
    private string Name { get; }

    private CourseLanguage(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("Language cannot be empty.");
        }

        Name = name;
    }

    public static CourseLanguage Create(string name) => new CourseLanguage(name);
}