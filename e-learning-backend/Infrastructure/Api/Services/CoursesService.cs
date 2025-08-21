using e_learning_backend.Infrastructure.Api.DTO;
using e_learning_backend.Infrastructure.Persistence.DatabaseContexts;
using e_learning_backend.Infrastructure.Security.Impl.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace e_learning_backend.Infrastructure.Security.Impl;

public class CoursesService : ICoursesService
{
    private readonly ApplicationContext _context;
    private readonly IConfiguration _configuration;


    public CoursesService(ApplicationContext context, IConfiguration configuration)
    {
        _context = context;
        _configuration = configuration;
    }


    public async Task<IEnumerable<CourseWidgetDTO>> GetCoursesAsync(
        string[]? categories,
        string[]? levels,
        string[]? languages,
        int? priceFrom,
        int? priceTo,
        Guid? teacherId)
    {
        var query = _context.Courses
            .Include(c => c.Variants)
            .Include(c => c.Teacher)
            .Include(c => c.Participations)
            .AsQueryable();


        if (categories is { Length: > 0 })
            query = query.Where(c => categories.Contains(c.Category.Name));

        if (teacherId.HasValue)
            query = query.Where(c => c.TeacherId == teacherId.Value);

        if (levels is { Length: > 0 })
            query = query.Where(c => c.Variants.Any(v => levels.Contains(v.Level.Name)));

        if (languages is { Length: > 0 })
            query = query.Where(c => c.Variants.Any(v => languages.Contains(v.Language.Name)));

        if (priceFrom.HasValue)
            query = query.Where(c => c.Variants.Any(v => v.Rate.Amount >= priceFrom.Value));

        if (priceTo.HasValue)
            query = query.Where(c => c.Variants.Any(v => v.Rate.Amount <= priceTo.Value));

        var courses = await query.ToListAsync();

        return courses.Select(c => new CourseWidgetDTO
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
                : 0, // jeśli brak recenzji, rating = 0
            Variants = c.Variants
                .Where(v =>
                    v != null &&
                    v.Level != null &&
                    v.Language != null &&
                    v.Rate != null &&
                    (levels == null || levels.Contains(v.Level.Name)) &&
                    (languages == null || languages.Contains(v.Language.Name)) &&
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
}
