using e_learning_backend.Domain.ExercisesAndMaterials;
using e_learning_backend.Infrastructure.Api.DTO;
using e_learning_backend.Infrastructure.Persistence.Repositories;
using e_learning_backend.Infrastructure.Persistence.Repositories.Impl;
using e_learning_backend.Infrastructure.Security.Impl.Interfaces;

namespace e_learning_backend.Application.Services;

public class StudentsService : IStudentsService
{
    private readonly IStudentsRepository _studentsRepository;
    private readonly IParticipationRepository _participationRepository;
    private readonly IClassRepository _classRepository;

    public StudentsService(IStudentsRepository studentsRepository, IParticipationRepository participationRepository, IClassRepository classRepository)
    {
        _studentsRepository = studentsRepository;
        _participationRepository = participationRepository;
        _classRepository = classRepository;
    }

    public async Task<StudentDTO?> GetStudentWithCoursesAsync(Guid studentId)
    {
        var student = await _studentsRepository.GetStudentWithCoursesAsync(studentId);

        if (student == null) return null;

        return new StudentDTO
        {
            Name = $"{student.Name} {student.Surname}",
            CoursesBrief = student.Participations
                .Select(p => new CourseBriefDTO
                {
                    Id = p.Course.Id,
                    Name = p.Course.Name
                })
                .ToList()
        };
    }
    
    public async Task<IEnumerable<ClassBriefDto>> GetTimelineAsync(
        Guid studentId,
        IEnumerable<Guid>? courseIds,
        DateTime from,
        DateTime to)
    {
        // jeśli nie podano konkretnych kursów → pobierz wszystkie dla usera
        var participations = courseIds?.Any() == true
            ? await _participationRepository.GetByIdsAsync(studentId, courseIds)
            : await _participationRepository.GetByUserIdAsync(studentId);
        
        if (!participations.Any())
            return Enumerable.Empty<ClassBriefDto>();

        var selectedCourseIds = participations.Select(p => p.CourseId).ToList();

        var classes = await _classRepository.GetByUserAndCoursesInDateRangeAsync(studentId, selectedCourseIds, from, to);
        
        return classes.Select(c => new ClassBriefDto
        {
            Id = c.Id,
            StartTime = c.StartTime,
            Status = c.Status.getStatus(),
            LinkToMeeting = c.LinkToMeeting,
            Links = c.Links?.Select(l => l.Link).ToHashSet() ?? new HashSet<string>(),
            UserId = studentId,
            CourseId = c.CourseId,
            CourseName = c.Participation.Course.Name,
            Exercises = c.Exercises.Select(e => new ExercisePreviewDto
            {
                Id = e.Id,
                ExerciseStatus = e.Status.ToString(),
                Grade = e.Grade
            }),
            Quizzes = c.Quizzes.Select(q => new QuizPreviewDto
            {
                Id = q.Id,
                Score = q.Score
            }),
            Files = c.Files.Select(f => new FilePreviewDto
            {
                Id = f.Id,
                Name = f.Name,
                Path = f.Path
            })
        });
    }

    public async Task<IEnumerable<CourseBriefDTO>> GetStudentCoursesAsync(Guid studentId)
    {
        return await _studentsRepository.GetStudentCourses(studentId);
    }
}