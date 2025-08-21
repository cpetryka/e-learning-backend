namespace e_learning_backend.Infrastructure.Api.DTO;

   public class CourseWidgetDTO
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string? Image { get; set; } // thumbnail (opcjonalne)
    public double? Rating { get; set; }
    public string Description { get; set; }
    
    public List<CourseVariantDTO> Variants { get; set; } = new();

    // nauczyciel
    public Guid TeacherId { get; set; }
    public string TeacherName { get; set; }
    public string TeacherSurname { get; set; }

    public class CourseVariantDTO
    {
        public string LanguageName { get; set; }
        public string LevelName { get; set; }
        public decimal Price { get; set; }
    }
}
