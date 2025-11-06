namespace e_learning_backend.Infrastructure.Api.DTO;

public class ClassBriefDto
{
    public Guid Id { get; set; }
    public DateTime StartTime { get; set; }
    public string Status { get; set; } = default!;
    public string? LinkToMeeting { get; set; }
    public IEnumerable<string> Links { get; set; } = new List<string>();
    
    public Guid UserId { get; set; }
    public Guid CourseId { get; set; }
    public string CourseName { get; set; } = default!;

    public IEnumerable<ExercisePreviewDto> Exercises { get; set; } = new List<ExercisePreviewDto>();
    public IEnumerable<QuizPreviewDto> Quizzes { get; set; } = new List<QuizPreviewDto>();
    public IEnumerable<FilePreviewDto> Files { get; set; } = new List<FilePreviewDto>();
}

public class ExercisePreviewDto
{
    public Guid Id { get; set; }
    public string ExerciseStatus { get; set; } = default!;
    public double? Grade { get;set; }
}

public class QuizPreviewDto
{
    public Guid Id { get; set; }
    public String Title { get; set; } = default!;
    public double? Score { get;set; }
}

public class FilePreviewDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
    public string Path { get; set; } = default!;
}
