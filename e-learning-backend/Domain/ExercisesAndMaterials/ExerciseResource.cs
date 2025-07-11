using e_learning_backend.Domain.ExercisesAndMaterials.ValueObjects;

namespace e_learning_backend.Domain.ExercisesAndMaterials;

public class ExerciseResource
{
    public Guid ExerciseId { get; set; }
    public Exercise Exercise { get; set; }
    
    public Guid FileId { get; set; }
    public FileResource File { get; set; }
    
    public ExerciseResourceType Type { get; set; }
    
    protected ExerciseResource() {}
    
    public ExerciseResource(Exercise exercise, FileResource file, ExerciseResourceType type)
    {
        Exercise = exercise ?? throw new ArgumentNullException(nameof(exercise), "Exercise cannot be null.");
        File = file ?? throw new ArgumentNullException(nameof(file), "File cannot be null.");
        Type = type;
        
        ExerciseId = exercise.Id;
        FileId = file.Id;
    }
}