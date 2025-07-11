using e_learning_backend.Domain.Classes;
using e_learning_backend.Domain.ExercisesAndMaterials.ValueObjects;

namespace e_learning_backend.Domain.ExercisesAndMaterials;

public class Exercise
{
    public Guid Id { get; private set; }
    public string? Instruction { get; private set; }
    public double? Grade { get; private set; }
    public string? Comment { get; private set; }
    public ExerciseStatus Status { get; private set; }
    
    public Guid ClassId { get; set; }
    public Class Class { get; set; }
    
    private readonly HashSet<ExerciseResource> _exerciseResources = new();
    public IReadOnlyCollection<ExerciseResource> ExerciseResources => _exerciseResources;
    
    protected Exercise() { }

    public Exercise(Guid id, string instruction, Class? associatedClass)
    {
        Id = id;
        Instruction = instruction;
        Status = ExerciseStatus.Unsolved;
        Class = associatedClass ?? throw new ArgumentNullException(nameof(associatedClass));
        ClassId = associatedClass.Id;
    }

    public Exercise(string instruction, Class? associatedClass) 
        : this(Guid.NewGuid(), instruction, associatedClass) { }

    public void gradeExercise(double grade, string? comment)
    {
        if (grade < 0 || grade > 5)
        {
            throw new ArgumentOutOfRangeException(nameof(grade), "Grade must be between 0 and 5.");
        }
        
        Grade = grade;
        Comment = comment;
        Status = ExerciseStatus.Graded;
    }

    public void addContentFile(FileResource file)
    {
        if (file == null)
        {
            throw new ArgumentNullException(nameof(file));
        }
        
        if (file.ExerciseResources.Any(er => er.ExerciseId == Id))
        {
            throw new InvalidOperationException("File is already associated with this exercise.");
        }
        
        var exerciseResource = new ExerciseResource(this, file, ExerciseResourceType.Content);
        
        _exerciseResources.Add(exerciseResource);
    }
    
    public void addSolutionFile(FileResource file)
    {
        if (file == null)
        {
            throw new ArgumentNullException(nameof(file));
        }
        
        if (file.ExerciseResources.Any(er => er.ExerciseId == Id))
        {
            throw new InvalidOperationException("File is already associated with this exercise.");
        }

        var exerciseResource = new ExerciseResource(this, file, ExerciseResourceType.Solution);
        
        _exerciseResources.Add(exerciseResource);
    }
}