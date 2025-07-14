using e_learning_backend.Domain.Users;

namespace e_learning_backend.Domain.ExercisesAndMaterials;

public class Tag
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    
    public Guid? TeacherId { get; set; }
    public User? Teacher { get; set; }
    
    private readonly HashSet<FileResource> _files = new();
    public IReadOnlyCollection<FileResource> Files => _files;
    
    protected Tag() { }
    
    public Tag(Guid id, string name, User teacher)
    {
        Id = id;
        Name = name ?? throw new ArgumentNullException(nameof(name), "Tag name cannot be null or empty.");
        Teacher = teacher ?? throw new ArgumentNullException(nameof(teacher), "Teacher cannot be null.");
        TeacherId = teacher.Id;
    }
    
    public Tag(Guid id, string name)
    {
        Id = id;
        Name = name ?? throw new ArgumentNullException(nameof(name), "Tag name cannot be null or empty.");
    }
    
    public Tag(string name, User teacher) : this(Guid.NewGuid(), name, teacher) { }
    
    public void AddFileToTagged(FileResource file)
    {
        if (file == null)
        {
            throw new ArgumentNullException(nameof(file), "File cannot be null.");
        }

        _files.Add(file);
    }
    
    public void RemoveFileFromTagged(FileResource file)
    {
        if (file == null)
        {
            throw new ArgumentNullException(nameof(file), "File cannot be null.");
        }

        if (!_files.Remove(file))
        {
            throw new InvalidOperationException("File is not associated with this tag.");
        }
    }
}