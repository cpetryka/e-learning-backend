namespace e_learning_backend.Infrastructure.Api.DTO;

   public class CourseWidgetDTO
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string? Image { get; set; } // thumbnail (opcjonalne)
    public double? Rating { get; set; }
    public string Description { get; set; }
    public decimal MinimumCoursePrice { get; set; } 
    public decimal MaximumCoursePrice { get; set; } 
    public string[] LevelVariants { get; set; } = null!; 
    public string[] LanguageVariants { get; set; } = null!; 

    // nauczyciel
    public Guid TeacherId { get; set; }
    public string TeacherName { get; set; }
    public string TeacherSurname { get; set; }

  
}
