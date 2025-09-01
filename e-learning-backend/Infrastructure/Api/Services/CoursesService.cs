using e_learning_backend.Domain.Courses;
using e_learning_backend.Infrastructure.Api.DTO;
using e_learning_backend.Infrastructure.Persistence.Repositories;
using e_learning_backend.Infrastructure.Security.Impl.Interfaces;

namespace e_learning_backend.Infrastructure.Security.Impl;

public class CoursesService : ICoursesService
{
    private readonly ICourseRepository _courseRepository;
    private readonly ITeacherService _teacherService;

    public CoursesService(ICourseRepository courseRepository, ITeacherService teacherService)
    {
        _courseRepository = courseRepository;
        _teacherService = teacherService;
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
            .Where(c => languages == null || languages.Length == 0 ||
                        c.Variants.Any(v => languages.Contains(v.Language.Name)))
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
            Variants = c.Variants
                .Where(v =>
                    v != null &&
                    v.Level != null &&
                    v.Language != null &&
                    v.Rate != null &&
                    (levels == null || levels.Length == 0 || levels.Contains(v.Level.Name)) &&
                    (languages == null || languages.Length == 0 || languages.Contains(v.Language.Name)) &&
                    (!priceFrom.HasValue || v.Rate.Amount >= priceFrom.Value) &&
                    (!priceTo.HasValue || v.Rate.Amount <= priceTo.Value)
                )
                .Select(v => new CourseWidgetDTO.CourseVariantDTO
                {
                    LanguageName = v.Language?.Name ?? "Unknown",
                    LevelName = v.Level?.Name ?? "Unknown",
                    Price = v.Rate?.Amount ?? 0
                }).ToList()
        }).ToList();
    }

    public async Task<CourseDetailsDTO?> GetCourseDetailsAsync(Guid courseId)
    {
        var course = await _courseRepository.GetByIdAsync(courseId);
        if (course == null) return null;

        
        var teacher = await _teacherService.GetTeacherAsync(course.TeacherId);
        if (teacher == null) return null;
        
        var availability = await _teacherService.GetTeacherAvailabilityAsync(course.TeacherId);
        
        var reviews = await _teacherService.GetTeacherReviewsAsync(course.TeacherId);
        
        var teacherDto = new TeacherDTO
        {
            Name = teacher.Name,
            Surname = teacher.Surname,
            Description = teacher.Description,
            CoursesBrief = teacher.CoursesBrief,
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
                .Select(v => new CourseWidgetDTO.CourseVariantDTO
                {
                    LanguageName = v.Language?.Name ?? "Unknown",
                    LevelName = v.Level?.Name ?? "Unknown",
                    Price = v.Rate?.Amount ?? 0
                }).ToList(),
            Teacher = teacherDto,
            TeacherAvailability = availability.ToList(),
            TeacherReviews = reviews.ToList(), 
            
        };
    }
}