using e_learning_backend.Domain.Users;

namespace e_learning_backend.Domain.ExercisesAndMaterials;

public class FileResource
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Path { get; set; }
    public DateTime AddedAt { get; set; }
    
    public Guid UserId { get; set; }
    public User User { get; set; }
    
    private readonly HashSet<ExerciseResource> _exerciseResources = new();
    public IReadOnlyCollection<ExerciseResource> ExerciseResources => _exerciseResources;
    
    protected FileResource() { }
    
    public FileResource(Guid id, string name, string path, DateTime addedAt, User user)
    {
        Id = id;
        Name = name;
        Path = path;
        AddedAt = addedAt;
        User = user ?? throw new ArgumentNullException(nameof(user), "User cannot be null.");
        UserId = user.Id;
    }
    
    public FileResource(string name, string path, DateTime addedAt, User user)
        : this(Guid.NewGuid(), name, path, addedAt, user) { }
}