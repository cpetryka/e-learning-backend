using e_learning_backend.Domain.Users;

namespace e_learning_backend.Domain.ExercisesAndMaterials;

public class Tag
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    
    public Guid? UserId { get; set; }
    public User? User { get; set; }
    
    private readonly HashSet<FileResource> _files = new();
    public IReadOnlyCollection<FileResource> Files => _files;
    
    protected Tag() { }
    
    public Tag(Guid id, string name, User teacher)
    {
        Id = id;
        Name = name ?? throw new ArgumentNullException(nameof(name), "Tag name cannot be null or empty.");
        User = teacher ?? throw new ArgumentNullException(nameof(teacher), "Teacher cannot be null.");
        UserId = teacher.Id;
        teacher.AddTag(this);
    }
    
    public Tag(Guid id, string name, Guid userId)
    {
        Id = id;
        Name = name ?? throw new ArgumentNullException(nameof(name), "Tag name cannot be null or empty.");
        UserId = userId;
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