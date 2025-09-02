namespace e_learning_backend.Infrastructure.Api.DTO;

public class TeacherDTO
{
    public Guid TeacherId { get; set; }
    public string Name { get; set; } = default!;
    public string Surname { get; set; } = default!;
    public string? Description { get; set; }
    public List<CourseBriefDTO> CoursesBrief { get; set; } = new();
    public ProfilePictureDTO? ProfilePicture { get; set; }

    public class CourseBriefDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = default!;
    }
    public class ProfilePictureDTO
    {
        public string FileName { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;
        public DateTime UploadedAt { get; set; }
    }
    
}