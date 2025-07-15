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
    
    private readonly HashSet<Tag> _tags = new();
    public IReadOnlyCollection<Tag> Tags => _tags;
    
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
    
    public void AddTag(Tag tag)
    {
        if (tag == null)
        {
            throw new ArgumentNullException(nameof(tag), "Tag cannot be null.");
        }
        
        if (_tags.Any(t => t.Id == tag.Id))
        {
            throw new InvalidOperationException("Tag is already associated with this file.");
        }
        
        _tags.Add(tag);
        tag.AddFileToTagged(this);
    }
    
    public void RemoveTag(Tag tag)
    {
        if (tag == null)
        {
            throw new ArgumentNullException(nameof(tag), "Tag cannot be null.");
        }
        
        if (!_tags.Remove(tag))
        {
            throw new InvalidOperationException("Tag is not associated with this file.");
        }
        
        tag.RemoveFileFromTagged(this);
    }
    
    public void AddExerciseResource(ExerciseResource exerciseResource)
    {
        if (exerciseResource == null)
        {
            throw new ArgumentNullException(nameof(exerciseResource), "Exercise resource cannot be null.");
        }
        
        _exerciseResources.Add(exerciseResource);
    }
    
    public void RemoveExerciseResource(ExerciseResource exerciseResource)
    {
        if (exerciseResource == null)
        {
            throw new ArgumentNullException(nameof(exerciseResource), "Exercise resource cannot be null.");
        }
        
        if (!_exerciseResources.Remove(exerciseResource))
        {
            throw new InvalidOperationException("Exercise resource is not associated with this file.");
        }
    }
}