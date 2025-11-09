namespace e_learning_backend.Infrastructure.Api.DTO;

public class GetExerciseDTO
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string CourseName { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    public bool Graded { get; set; }
    public double? Grade { get; set; }
    public string Comments { get; set; } = string.Empty;
    public string Instruction { get; set; } = string.Empty;
    public DateTime Date { get; set; }
    public List<GetExerciseResourceDTO> Files { get; set; } = new List<GetExerciseResourceDTO>();
}