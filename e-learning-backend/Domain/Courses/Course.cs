using e_learning_backend.Domain.Courses.ValueObjects;

namespace e_learning_backend.Domain.Courses;

public class Course
{
    private Guid Id { get; set; }
    private string Name { get; set; }
    private CourseCategory Category { get; set; }
    private string Description { get; set; }
    private IList<CourseVariant> Variants { get; set; } = new List<CourseVariant>();

    private Course() { }

    public Course(string name, CourseCategory category, string description)
    {
        Id = Guid.NewGuid();
        Name = name ?? throw new ArgumentNullException(nameof(name));
        Category = category ?? throw new ArgumentNullException(nameof(category));
        Description = description ?? throw new ArgumentNullException(nameof(description));
    }

    public void AddVariant(CourseVariant variant)
    {
        if (variant == null)
        {
            throw new ArgumentNullException(nameof(variant));
        }

        if (Variants.Any(v => v.Level == variant.Level && v.Language == variant.Language))
        {
            throw new InvalidOperationException("Variant with the same level and language already exists.");
        }

        Variants.Add(variant);
    }
}