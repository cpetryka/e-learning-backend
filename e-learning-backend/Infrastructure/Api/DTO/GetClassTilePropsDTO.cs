namespace e_learning_backend.Infrastructure.Api.DTO;

public class GetClassTilePropsDTO
{
 public Guid Id { get; set; }
 public string State { get; set; } = default!;
 public DateTime Date { get; set; }
 public string? Title { get; set; }
 public int Duration { get; set; }
}