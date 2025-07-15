using e_learning_backend.Domain.Classes.ValueObjects;
using e_learning_backend.Domain.ExercisesAndMaterials;
using e_learning_backend.Domain.Participations;
using e_learning_backend.Domain.Quizzes;

namespace e_learning_backend.Domain.Classes;


public class Class
{
    public  Guid Id { get; private set; }
    public DateTime StartTime { get; private set; }
    public string? Comment { get; private set; }
    public string? LinkToMeeting { get; private set; }
    public ClassStatus Status { get; private set; }
    public HashSet<string> Links { get; } = new();
    
    public Guid UserId { get; set; }
    public Guid CourseId { get; set; }
    public Participation Participation { get; set; } 
    
    private readonly HashSet<Exercise> _exercises = new();
    public IReadOnlyCollection<Exercise> Exercises => _exercises;
    
    private readonly HashSet<Quiz> _quizzes = new();
    public IReadOnlyCollection<Quiz> Quizzes => _quizzes;
    
    private readonly HashSet<FileResource> _files = new();
    public IReadOnlyCollection<FileResource> Files => _files;
    
    public Class() { }
    public Class(
        Guid id, 
        DateTime startTime, 
        string? comment, 
        string? linkToMeeting, 
        ClassStatus status)
    {
        SetId(id);
        SetStartTime(startTime);
        SetComment(comment);
        SetLinkToMeeting(linkToMeeting);
        SetStatus(status);
    }
    
    public Class(
        DateTime startTime)
        : this(Guid.NewGuid(), startTime, "", "", new ClassStatus("new")) { }

    public void SetStartTime(DateTime startTime)
    {
        if (startTime < DateTime.Now)
        {
            throw new ArgumentException("Start time cannot be in the past.");
        }
        StartTime = startTime;
    }
    public void SetComment(string? comment)
    {
        if (comment?.Length > 500)
            throw new ArgumentException("Comment is too long (max 500 characters).");
        Comment = comment;
    }
    
    public void SetLinkToMeeting(string? linkToMeeting)
    {
        LinkToMeeting = linkToMeeting;
    }
    
    public void SetStatus(ClassStatus status)
    {
        if (status == null) {
            throw new ArgumentNullException(nameof(status));
        }
        
        Status = status;
    }
    
    private void SetId(Guid id)
    {
        Id = id;
    }
    
    public void AddExercise(Exercise exercise)
    {
        if (exercise == null)
        {
            throw new ArgumentNullException(nameof(exercise));
        }

        if (exercise.ClassId != Id)
        {
            throw new ArgumentException("Exercise IDs do not match.");
        }
        
        _exercises.Add(exercise);
    }
    
    public void AddQuiz(Quiz quiz)
    {
        if (quiz == null)
        {
            throw new ArgumentNullException(nameof(quiz));
        }

        _quizzes.Add(quiz);
    }
    
    public void RemoveQuiz(Quiz quiz)
    {
        if (quiz == null)
        {
            throw new ArgumentNullException(nameof(quiz));
        }

        if (!_quizzes.Contains(quiz))
        {
            throw new InvalidOperationException("Quiz does not exist for this course.");
        }

        _quizzes.Remove(quiz);
    }
    
    public void AddLink(string link)
    {
        if (string.IsNullOrWhiteSpace(link))
        {
            throw new ArgumentException("Link cannot be null or empty.", nameof(link));
        }
        
        Links.Add(link);
    }
    
    public void RemoveLink(string link)
    {
        if (string.IsNullOrWhiteSpace(link))
        {
            throw new ArgumentException("Link cannot be null or empty.", nameof(link));
        }
        
        if (!Links.Remove(link))
        {
            throw new InvalidOperationException("Link does not exist in the class.");
        }
    }
    
    public void AddFile(FileResource file) 
    {
        if (file == null)
        {
            throw new ArgumentNullException(nameof(file), "File cannot be null.");
        }

        _files.Add(file);
    }
    
    public void RemoveFile(FileResource file)
    {
        if (file == null)
        {
            throw new ArgumentNullException(nameof(file), "File cannot be null.");
        }

        if (!_files.Remove(file))
        {
            throw new InvalidOperationException("File does not exist in the class.");
        }
    }
}