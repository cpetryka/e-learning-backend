using e_learning_backend.Domain.Courses;
using e_learning_backend.Domain.Participations;
using e_learning_backend.Domain.Users.ValueObjects;
using e_learning_backend.Infrastructure.Api.DTO;
using e_learning_backend.Infrastructure.Persistence.Repositories;
using e_learning_backend.Infrastructure.Security.Impl.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace e_learning_backend.Application.Services;

public class CoursesService : ICoursesService
{
    private readonly ICourseRepository _courseRepository;
    private readonly ITeacherService _teacherService;
    private readonly IWebHostEnvironment _env;
    private readonly IConfiguration _configuration;

    private const long MaxFileSize = 5 * 1024 * 1024; // 5 MB
    private readonly string[] AllowedExtensions = { ".jpg", ".jpeg", ".png", ".gif", ".webp" };

    public CoursesService(ICourseRepository courseRepository, ITeacherService teacherService,
        IWebHostEnvironment env, IConfiguration configuration)
    {
        _courseRepository = courseRepository;
        _teacherService = teacherService;
        _env = env;
        _configuration = configuration;
    }

    // public async Task<IEnumerable<CourseWidgetDTO>> GetCoursesAsync(
    //     string[]? categories,
    //     string[]? levels,
    //     string[]? languages,
    //     int? priceFrom,
    //     int? priceTo,
    //     Guid? teacherId,
    //     string? query)
    // {
    //     var courses = await _courseRepository.GetAllAsync();
    //
    //     var filtered = courses
    //         .Where(c =>
    //             categories == null || categories.Length == 0 ||
    //             categories.Contains(c.Category.Name))
    //         .Where(c => !teacherId.HasValue || c.TeacherId == teacherId.Value)
    //         .Where(c =>
    //             levels == null || levels.Length == 0 ||
    //             c.Variants.Any(v => levels.Contains(v.Level.Name)))
    //         .Where(c =>
    //             languages == null || languages.Length == 0 ||
    //             c.Variants.Any(v => languages.Contains(v.Language.Name)))
    //         .Where(c =>
    //             !priceFrom.HasValue || c.Variants.Any(v => v.Rate.Amount >= priceFrom.Value))
    //         .Where(c => !priceTo.HasValue || c.Variants.Any(v => v.Rate.Amount <= priceTo.Value))
    //         .Where(c => string.IsNullOrEmpty(query) || c.MatchesSearchQuery(query))
    //         .ToList();
    //
    //     return filtered.Select(c => new CourseWidgetDTO
    //     {
    //         Id = c.Id,
    //         Name = c.Name,
    //         Description = c.Description,
    //         TeacherName = c.Teacher?.Name ?? "Unknown",
    //         TeacherSurname = c.Teacher?.Surname ?? "Unknown",
    //         TeacherId = c.Teacher?.Id ?? Guid.Empty,
    //         Rating = c.Participations != null && c.Participations.Any(p => p.Review != null)
    //             ? c.Participations
    //                 .Where(p => p.Review != null)
    //                 .Average(p => p.Review!.StarsNumber)
    //             : 0,
    //
    //         MinimumCoursePrice = c.Variants.Any(v => v.Rate != null)
    //             ? c.Variants.Min(v => v.Rate!.Amount)
    //             : 0,
    //
    //         MaximumCoursePrice = c.Variants.Any(v => v.Rate != null)
    //             ? c.Variants.Max(v => v.Rate!.Amount)
    //             : 0,
    //
    //         LevelVariants = c.Variants
    //             .Where(v =>
    //                 v.Level != null &&
    //                 (levels == null || levels.Length == 0 || levels.Contains(v.Level.Name)))
    //             .Select(v => v.Level!.Name)
    //             .Distinct()
    //             .ToArray(),
    //
    //         LanguageVariants = c.Variants
    //             .Where(v =>
    //                 v.Language != null &&
    //                 (languages == null || languages.Length == 0 ||
    //                  languages.Contains(v.Language.Name)))
    //             .Select(v => v.Language!.Name)
    //             .Distinct()
    //             .ToArray(),
    //         ProfilePictureUrl = c.ProfilePicture != null
    //             ? "http://localhost:5249/" + c.ProfilePicture.FilePath.Replace("\\", "/")
    //             : null
    //     }).ToList();
    // }

    public async Task<double> GetCourseAverageRatingAsync(Guid courseId)
    {
        var course = await _courseRepository.GetByIdAsync(courseId);
        if (course == null) return 0;

        var ratings = course.Variants?
            .SelectMany(v => v.Participations)
            .Where(p => p.Review != null)
            .Select(p => (double)p.Review!.StarsNumber)
            .DefaultIfEmpty(0);

        return ratings == null ? 0 : ratings.Average();
    }

    public async Task<List<TeacherAvailabilityDTO>> GetTeacherAvailabilityByCourseId(Guid courseId)
    {
        var course = await _courseRepository.GetByIdAsync(courseId);
        if (course is null || course.Teacher is null)
            return new List<TeacherAvailabilityDTO>();
        var teacherId = course.Teacher.Id;
        return await _teacherService.GetTeacherAvailabilityAsync(teacherId);
    }


public async Task<PagedResult<CourseWidgetDTO>> GetCoursesAsync(
    string[]? categories,
    string[]? levels,
    string[]? languages,
    int? priceFrom,
    int? priceTo,
    Guid? teacherId,
    string? query,
    int pageNumber,
    int pageSize)
{
    // 1. Inicjalizacja zapytania
    IQueryable<Course> coursesQuery = _courseRepository.GetAllQueryable();

    // 2. Aplikacja filtrów (SQL WHERE)
    if (categories != null && categories.Length > 0)
        coursesQuery = coursesQuery.Where(c => categories.Contains(c.Category.Name));

    if (levels != null && levels.Length > 0)
        coursesQuery = coursesQuery.Where(c => c.Variants.Any(v => levels.Contains(v.Level.Name)));

    if (languages != null && languages.Length > 0)
        coursesQuery = coursesQuery.Where(c => c.Variants.Any(v => languages.Contains(v.Language.Name)));

    if (priceFrom.HasValue)
        coursesQuery = coursesQuery.Where(c => c.Variants.Any(v => v.Rate.Amount >= priceFrom.Value));

    if (priceTo.HasValue)
        coursesQuery = coursesQuery.Where(c => c.Variants.Any(v => v.Rate.Amount <= priceTo.Value));

    if (teacherId.HasValue)
        coursesQuery = coursesQuery.Where(c => c.TeacherId == teacherId.Value);

    if (!string.IsNullOrWhiteSpace(query))
        coursesQuery = coursesQuery.Where(c => c.Name.Contains(query) || c.Description.Contains(query));

    // 3. Liczenie wyników (wykonuje zapytanie SELECT COUNT)
    var totalCount = await coursesQuery.CountAsync();

    // 4. Pobieranie danych (Dopiero tutaj dodajemy Include, bo są potrzebne do mapowania)
    // WAŻNE: Musisz dodać .Include(), aby EF pobrał powiązane dane,
    // ponieważ rezygnujemy z .Select() na poziomie bazy.
    var courses = await coursesQuery
        .Include(c => c.Category)
        .Include(c => c.Teacher)
        .Include(c => c.ProfilePicture)
        .Include(c => c.Variants)
            .ThenInclude(v => v.Level)
        .Include(c => c.Variants)
            .ThenInclude(v => v.Language)
        .Include(c => c.Variants)
            .ThenInclude(v => v.Rate) // Potrzebne do cen
        .Include(c => c.Variants)
            .ThenInclude(v => v.Participations) // Potrzebne do gwiazdek (ocen)
            .ThenInclude(p => p.Review)
        .OrderBy(c => c.Name)
        .Skip((pageNumber - 1) * pageSize)
        .Take(pageSize)
        .ToListAsync(); // <--- TU WYKONUJE SIĘ SQL (Materializacja danych)

    // 5. Mapowanie w pamięci (C#)
    // Teraz operujemy na liście w pamięci RAM, więc ToArray(), Replace() itp. są bezpieczne.
    var courseDtos = courses.Select(c => new CourseWidgetDTO
    {
        Id = c.Id,
        Name = c.Name,
        Description = c.Description,
        TeacherName = c.Teacher != null ? c.Teacher.Name : "Unknown",
        TeacherSurname = c.Teacher != null ? c.Teacher.Surname : "Unknown",
        TeacherId = c.TeacherId,
        
        // Obliczanie średniej oceny w pamięci (bezpieczniejsze dla nulli)
        Rating = c.Variants
            .SelectMany(v => v.Participations)
            .Where(p => p.Review != null)
            .Select(p => (double)p.Review!.StarsNumber)
            .DefaultIfEmpty(0)
            .Any() ? c.Variants.SelectMany(v => v.Participations).Where(p => p.Review != null).Average(p => p.Review!.StarsNumber) : 0,

        // Ceny
        MinimumCoursePrice = c.Variants.Any(v => v.Rate != null)
            ? c.Variants.Min(v => v.Rate!.Amount)
            : 0,
        MaximumCoursePrice = c.Variants.Any(v => v.Rate != null)
            ? c.Variants.Max(v => v.Rate!.Amount)
            : 0,

        // Warianty (tablice stringów - to powodowało błąd wcześniej w SQL)
        LevelVariants = c.Variants
            .Where(v => v.Level != null)
            .Select(v => v.Level!.Name)
            .Distinct()
            .ToArray(),

        LanguageVariants = c.Variants
            .Where(v => v.Language != null)
            .Select(v => v.Language!.Name)
            .Distinct()
            .ToArray(),

        ProfilePictureUrl = c.ProfilePicture != null
            ? _configuration.GetSection("FileDirectory:Directory").Value + c.ProfilePicture.FilePath.Replace("\\", "/")
            : null
    }).ToList();

    return new PagedResult<CourseWidgetDTO>
    {
        Items = courseDtos,
        TotalCount = totalCount,
        Page = pageNumber,
        PageSize = pageSize
    };
}

    public async Task<IEnumerable<CourseWidgetDTO>> GetCoursesBasedOnQuery(string query)
    {
        var courses = await _courseRepository.GetAllAsync();

        return courses
            .Where(course => course.MatchesSearchQuery(query))
            .Select(c => new CourseWidgetDTO
            {
                Id = c.Id,
                Name = c.Name,
                Description = c.Description,
                ProfilePictureUrl = c.ProfilePicture?.FilePath,
                Rating = (c.Variants != null && c.Variants.Any())
                    ? c.Variants
                        .SelectMany(v => v.Participations ?? Enumerable.Empty<Participation>())
                        .Where(p => p.Review != null)
                        .Select(p => (double)p.Review!.StarsNumber)
                        .DefaultIfEmpty(0)
                        .Average()
                    : 0,
                MinimumCoursePrice = (c.Variants != null && c.Variants.Any())
                    ? c.Variants.Min(v => v.Rate!.Amount)
                    : 0,
                MaximumCoursePrice = (c.Variants != null && c.Variants.Any())
                    ? c.Variants.Max(v => v.Rate!.Amount)
                    : 0,
                LevelVariants = c.Variants != null
                    ? c.Variants.Where(v => v.Level != null).Select(v => v.Level!.Name).Distinct()
                        .ToArray()
                    : Array.Empty<string>(),
                LanguageVariants = c.Variants != null
                    ? c.Variants.Where(v => v.Language != null).Select(v => v.Language!.Name)
                        .Distinct().ToArray()
                    : Array.Empty<string>(),
                TeacherId = c.TeacherId,
                TeacherName = c.Teacher?.Name ?? "Unknown",
                TeacherSurname = c.Teacher?.Surname ?? "Unknown"
            });
    }

    public async Task<CourseDetailsDTO?> GetCourseDetailsAsync(Guid courseId)
    {
        var course = await _courseRepository.GetByIdAsync(courseId);
        if (course == null) return null;

        var teacher = await _teacherService.GetTeacherAsync(course.TeacherId);
        if (teacher == null) return null;

        var teacherDto = new TeacherDTO
        {
            TeacherId = teacher.TeacherId,
            Name = teacher.Name,
            Surname = teacher.Surname,
            Description = teacher.Description,
            CoursesBrief = teacher.CoursesBrief,
            TeacherProfilePictureUrl = teacher.TeacherProfilePictureUrl
        };

        double rating = 0;

        var participations = new List<Participation>();
        if (course.Variants != null)
        {
            foreach (var v in course.Variants)
            {
                if (v.Participations != null)
                    participations.AddRange(v.Participations);
            }
        }

        var courseReviews = participations
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
            Variants = course.Variants?
                .Where(v => v != null)
                .Select(v => new CourseVariantDTO
                {
                    LanguageName = v.Language?.Name ?? "Unknown",
                    LanguageId = v.Language.Id,
                    LevelName = v.Level?.Name ?? "Unknown",
                    LevelId = v.Level.Id,
                    Price = v.Rate?.Amount ?? 0
                }).ToList() ?? new List<CourseVariantDTO>(),
            Teacher = teacherDto,
            ProfilePictureUrl = course.ProfilePicture != null
                ?  _configuration.GetSection("FileDirectory:Directory").Value + course.ProfilePicture.FilePath.Replace("\\", "/")
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

    public async Task<(bool Success, string Message, ProfilePicture? ProfilePicture)>
        UploadProfilePictureAsync(
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

        var uploadsFolder =
            Path.Combine(_env.WebRootPath!, "uploads", "courses", courseId.ToString());
        Directory.CreateDirectory(uploadsFolder);

        var fileName = $"profile-picture{extension}";
        var filePath = Path.Combine(uploadsFolder, fileName);

        using (var stream = new FileStream(filePath, FileMode.Create))
            await file.CopyToAsync(stream);

        var profilePicture = new ProfilePicture(fileName,
            Path.Combine("uploads", "courses", courseId.ToString(), fileName));
        course.SetProfilePicture(profilePicture);

        await _courseRepository.UpdateAsync(course);

        return (true, "Course profile picture uploaded successfully.", profilePicture);
    }
}