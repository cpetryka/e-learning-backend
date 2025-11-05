using e_learning_backend.Domain.ExercisesAndMaterials;

namespace e_learning_backend.Infrastructure.Api.DTO;

public class GetFileDTO
{
    public Guid Id { get; set; }
    public string FileName { get; set; } = string.Empty;
    public string RelativePath { get; set; } = string.Empty;
    public DateTime UploadedAt { get; set; }
    public IEnumerable<TagDTO> Tags { get; set; } = Enumerable.Empty<TagDTO>();
    
    public string FileType => Path.GetExtension(FileName)
        .TrimStart('.')
        .ToUpperInvariant();
    
    public List<UserDTO?> ParticipationUsers { get; set; } = new List<UserDTO?>();

    public GetFileDTO()
    {
    }
    
    public class TagDTO
    {
        public Guid Id { get; set; }
        public Guid ?OwnerId { get; set; }
        public string Name { get; set; } = string.Empty;
    }
    
    public class UserDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
    }

}