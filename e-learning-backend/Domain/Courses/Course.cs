using e_learning_backend.Domain.Courses.ValueObjects;

namespace e_learning_backend.Domain.Courses;

/// <summary>
///     Represents a course.
/// </summary>
public class Course
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public CourseCategory Category { get; private set; }
    public string Description { get; private set; }

    private readonly List<CourseVariant> _variants = new();
    public IReadOnlyCollection<CourseVariant> Variants => _variants.AsReadOnly();

    public Course() { }

    public Course(string name, CourseCategory category, string description)
    {
        Id = Guid.NewGuid();
        Name = name ?? throw new ArgumentNullException(nameof(name));
        Category = category ?? throw new ArgumentNullException(nameof(category));
        Description = description ?? throw new ArgumentNullException(nameof(description));
    }

    /// <summary>
    ///     Adds a new course variant to the course. It is the only method of adding new course variants
    ///     (as the list is encapsulated).
    /// </summary>
    /// <param name="variant">The course variant to add.</param>
    /// <exception cref="ArgumentNullException">Thrown when the provided variant is null.</exception>
    /// <exception cref="InvalidOperationException">
    ///     Thrown when a variant with the same level and language already exists.
    /// </exception>
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

        _variants.Add(variant);
    }

    /// <summary>
    ///     Removes a course variant from the course by its unique identifier.
    ///     It is the only method of adding new course variants (as the list is encapsulated).
    /// </summary>
    /// <param name="variantId">The unique identifier of the variant to remove.</param>
    public void RemoveVariant(Guid variantId)
    {
        var variant = _variants.FirstOrDefault(v => v.Id == variantId);

        if (variant != null)
        {
            _variants.Remove(variant);
        }
    }
}