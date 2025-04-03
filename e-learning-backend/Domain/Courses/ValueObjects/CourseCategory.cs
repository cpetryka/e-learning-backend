namespace e_learning_backend.Domain.Courses.ValueObjects;

public record CourseCategory
{
    public string Name { get; }

    private CourseCategory(string name)
    {
        if (string.IsNullOrWhiteSpace(name) || name.Length < 3)
        {
            throw new ArgumentException("Category cannot be empty or less than 3 characters long.");
        }

        Name = name;
    }

    public static CourseCategory Create(string name) => new CourseCategory(name);
}
