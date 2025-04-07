namespace e_learning_backend.Domain.Courses;


/// <summary>
///     Represents a course category.
/// </summary>
public class CourseCategory
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }

    private CourseCategory() { }

    public CourseCategory(Guid id, string name)
    {
        if (string.IsNullOrWhiteSpace(name) || name.Length < 3)
        {
            throw new ArgumentException("Category name cannot be empty or less than 3 characters long.");
        }

        Id = id;
        Name = name;
    }

    public CourseCategory(string name) : this(Guid.NewGuid(), name) { }
}

