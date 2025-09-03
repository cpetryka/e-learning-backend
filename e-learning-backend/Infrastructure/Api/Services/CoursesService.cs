using e_learning_backend.Domain.Courses;
using e_learning_backend.Domain.Users.ValueObjects;
using e_learning_backend.Infrastructure.Api.DTO;
using e_learning_backend.Infrastructure.Persistence.Repositories;
using e_learning_backend.Infrastructure.Security.Impl.Interfaces;

namespace e_learning_backend.Infrastructure.Security.Impl;

public class CoursesService : ICoursesService
{
    private readonly ICourseRepository _courseRepository;
    private readonly ITeacherService _teacherService;
    private readonly IWebHostEnvironment _env;
    
    private const long MaxFileSize = 5 * 1024 * 1024; // 5 MB
    private readonly string[] AllowedExtensions = { ".jpg", ".jpeg", ".png", ".gif", ".webp" };

    public CoursesService(ICourseRepository courseRepository, ITeacherService teacherService,IWebHostEnvironment env)
    {
        _courseRepository = courseRepository;
        _teacherService = teacherService;
        _env = env;
    }
    
   public async Task<IEnumerable<CourseWidgetDTO>> GetCoursesAsync(
    string[]? categories,
    string[]? levels,
    string[]? languages,
    int? priceFrom,
    int? priceTo,
    Guid? teacherId)
{
    var courses = await _courseRepository.GetAllAsync();

    var filtered = courses
        .Where(c => categories == null || categories.Length == 0 || categories.Contains(c.Category.Name))
        .Where(c => !teacherId.HasValue || c.TeacherId == teacherId.Value)
        .Where(c => levels == null || levels.Length == 0 || c.Variants.Any(v => levels.Contains(v.Level.Name)))
        .Where(c => languages == null || languages.Length == 0 || c.Variants.Any(v => languages.Contains(v.Language.Name)))
        .Where(c => !priceFrom.HasValue || c.Variants.Any(v => v.Rate.Amount >= priceFrom.Value))
        .Where(c => !priceTo.HasValue || c.Variants.Any(v => v.Rate.Amount <= priceTo.Value))
        .ToList();

    return filtered.Select(c => new CourseWidgetDTO
    {
        Id = c.Id,
        Name = c.Name,
        Description = c.Description,
        TeacherName = c.Teacher?.Name ?? "Unknown",
        TeacherSurname = c.Teacher?.Surname ?? "Unknown",
        TeacherId = c.Teacher?.Id ?? Guid.Empty,
        Rating = c.Participations != null && c.Participations.Any(p => p.Review != null)
            ? c.Participations
                .Where(p => p.Review != null)
                .Average(p => p.Review!.StarsNumber)
            : 0,
        
        MinimumCoursePrice = c.Variants.Any(v => v.Rate != null)
            ? c.Variants.Min(v => v.Rate!.Amount)
            : 0,

        MaximumCoursePrice = c.Variants.Any(v => v.Rate != null)
            ? c.Variants.Max(v => v.Rate!.Amount)
            : 0,

        LevelVariants = c.Variants
            .Where(v =>
                v.Level != null &&
                (levels == null || levels.Length == 0 || levels.Contains(v.Level.Name)))
            .Select(v => v.Level!.Name)
            .Distinct()
            .ToArray(),

        LanguageVariants = c.Variants
            .Where(v =>
                v.Language != null &&
                (languages == null || languages.Length == 0 || languages.Contains(v.Language.Name)))
            .Select(v => v.Language!.Name)
            .Distinct()
            .ToArray(),
            ProfilePictureUrl = c.ProfilePicture != null
            ? "http://localhost:5249/" + c.ProfilePicture.FilePath.Replace("\\", "/")
            : null
    }).ToList();
}



    public async Task<CourseDetailsDTO?> GetCourseDetailsAsync(Guid courseId)
    {
        var course = await _courseRepository.GetByIdAsync(courseId);
        if (course == null) return null;

        
        var teacher = await _teacherService.GetTeacherAsync(course.TeacherId);
        if (teacher == null) return null;
        
        // var availability = await _teacherService.GetTeacherAvailabilityAsync(course.TeacherId);
        
        // var reviews = await _teacherService.GetTeacherReviewsAsync(course.TeacherId);
        
        var teacherDto = new TeacherDTO
        {
            Name = teacher.Name,
            Surname = teacher.Surname,
            Description = teacher.Description,
            CoursesBrief = teacher.CoursesBrief,
            TeacherProfilePictureUrl = teacher.TeacherProfilePictureUrl
        };

        
        double rating = 0;
        var courseReviews = course.Participations
            .Where(p => p.Review != null)
            .Select(p => p.Review!)
            .ToList();

        if (courseReviews.Any())
            rating = courseReviews.Average(r => r.StarsNumber);

        
        return new CourseDetailsDTO
        {
            Id = course.Id,
            Name = course.Name,
            Category = course.Category?.Name,
            Description = course.Description,
            Rating = rating,
            Variants = course.Variants
                .Where(v => v != null)
                .Select(v => new CourseVariantDTO
                {
                    LanguageName = v.Language?.Name ?? "Unknown",
                    LevelName = v.Level?.Name ?? "Unknown",
                    Price = v.Rate?.Amount ?? 0
                }).ToList(),
            Teacher = teacherDto,
            ProfilePictureUrl = course.ProfilePicture != null
                ? "http://localhost:5249/" + course.ProfilePicture.FilePath.Replace("\\", "/")
                : null
        };
    }

    public async Task<IReadOnlyCollection<CourseCategory>> GetAllDistinctCategoriesAsync()
    {
        return await _courseRepository.GetAllDistinctCategoriesAsync();
    }
    public async Task<IReadOnlyCollection<CourseLevel>> GetAllDistinctLevelsAsync()
    {
        return await _courseRepository.GetAllDistinctLevelsAsync();
    }
    public async Task<IReadOnlyCollection<CourseLanguage>> GetAllDistinctLanguagesAsync()
    {
        return await _courseRepository.GetAllDistinctLanguagesAsync();
    }
    
    public async Task<(bool Success, string Message, ProfilePicture? ProfilePicture)> UploadProfilePictureAsync(
        Guid courseId, Guid userId, IFormFile file)
    {
        if (file == null || file.Length == 0)
            return (false, "No file uploaded.", null);
        if (file.Length > MaxFileSize)
            return (false, "File is too large.", null);

        var extension = Path.GetExtension(file.FileName).ToLowerInvariant();
        if (!AllowedExtensions.Contains(extension))
            return (false, "Invalid file type.", null);

        var course = await _courseRepository.GetByIdAsync(courseId);
        if (course == null)
            return (false, "Course not found.", null);

        if (course.TeacherId != userId)
            return (false, "You are not the owner of this course.", null);

        var uploadsFolder = Path.Combine(_env.WebRootPath!, "uploads", "courses", courseId.ToString());
        Directory.CreateDirectory(uploadsFolder);

        var fileName = $"profile-picture{extension}";
        var filePath = Path.Combine(uploadsFolder, fileName);

        using (var stream = new FileStream(filePath, FileMode.Create))
            await file.CopyToAsync(stream);

        var profilePicture = new ProfilePicture(fileName, Path.Combine("uploads", "courses", courseId.ToString(), fileName));
        course.SetProfilePicture(profilePicture);

        await _courseRepository.UpdateAsync(course);

        return (true, "Course profile picture uploaded successfully.", profilePicture);
    }
}
