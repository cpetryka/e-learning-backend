using e_learning_backend.API.DTOs;
using e_learning_backend.Domain.Classes;
using e_learning_backend.Domain.ExercisesAndMaterials;
using e_learning_backend.Infrastructure.Api.DTO;
using e_learning_backend.Infrastructure.Persistence.Repositories;
using e_learning_backend.Infrastructure.Persistence.Repositories.Impl;
using e_learning_backend.Infrastructure.Security.Impl.Interfaces;
using Microsoft.AspNetCore.Mvc;

public class ClassesService : IClassesService
{
    private readonly IClassRepository _repository;
    private readonly ILinkResourcesRepository _linkResourcesRepository;
    private readonly IParticipationRepository _participationRepository;
    private readonly ITeacherRepository _teacherRepository;

    public ClassesService(IClassRepository repository,
        ILinkResourcesRepository linkResourcesRepository, 
        IParticipationRepository participationRepository,
        ITeacherRepository teacherRepository)
    {
        _repository = repository;
        _linkResourcesRepository = linkResourcesRepository;
        _participationRepository = participationRepository;
        _teacherRepository = teacherRepository;
    }

    /// <summary>
    /// Retrieves all upcoming classes for a specific student within the next 14 days (UTC).
    /// </summary>
    /// <param name="studentId">The unique identifier of the student.</param>
    public Task<IEnumerable<ClassDTO>> GetUpcomingClassesForStudentAsync(Guid studentId)
        => _repository.GetUpcomingClassesForStudentAsync(studentId);


    /// <summary>
    /// Retrieves all upcoming classes for a specific teacher within the next 14 days (UTC).
    /// </summary>
    /// <param name="teacherId">The unique identifier of the teacher.</param>
    public Task<IEnumerable<ClassDTO>> GetUpcomingClassesForTeacherAsync(Guid teacherId)
        => _repository.GetUpcomingClassesForTeacherAsync(teacherId);

    public async Task<ClassBriefDto?> GetClassBriefAsync(Guid classId)
    {
        var cls = await _repository.GetByIdAsync(classId);

        if (cls == null)
            return null;

        var dto = new ClassBriefDto
        {
            Id = cls.Id,
            StartTime = cls.StartTime,
            Status = cls.Status.Status,
            LinkToMeeting = cls.LinkToMeeting,
            Links = (cls.LinkToMeeting != null
                ? new[] { cls.LinkToMeeting }.Concat(cls.Links.Select(link => link.Link))
                : cls.Links.Select(link => link.Link)),
            UserId = cls.UserId,
            CourseId = cls.Participation.CourseVariant.Course.Id,
            CourseName = cls.Participation.CourseVariant.Course.Name ?? "Unknown",

            Exercises = cls.Exercises.Select(ex => new ExercisePreviewDto
            {
                Id = ex.Id,
                ExerciseStatus = ex.Status.ToString(),
                Grade = ex.Grade
            }),

            Quizzes = cls.Quizzes.Select(qz => new QuizPreviewDto
            {
                Id = qz.Id,
                Title = qz.Title,
                Score = qz.Score
            }),

            Files = cls.Files.Select(f => new FilePreviewDto
            {
                Id = f.Id,
                Name = f.Name,
                Path = f.Path
            })
        };

        return dto;
    }

    public async Task<bool> AddLinkAsync(Guid userId, Guid classId, string link, bool isMeeting)
    {
        if (string.IsNullOrWhiteSpace(link))
        {
            throw new ArgumentException("Link cannot be empty.", nameof(link));
        }

        var cls = await _repository.GetByIdAsync(classId);
        if (cls == null)
        {
            throw new ArgumentException("Class not found.");
        }

        // Only course teacher may add links
        var teacherId = cls.Participation?.CourseVariant?.Course?.TeacherId;
        if (teacherId is null || teacherId != userId)
        {
            return false;
        }

        if (isMeeting)
        {
            cls.SetLinkToMeeting(link);
        }
        else
        {
            var linkResource = new LinkResource(link, cls);
            await _linkResourcesRepository.AddAsync(linkResource);
        }

        await _repository.UpdateAsync(cls);
        return true;
    }

    public async Task<bool> RemoveLinkAsync(Guid userId, Guid linkId)
    {
        if (linkId == Guid.Empty)
        {
            throw new ArgumentException("Invalid link id.", nameof(linkId));
        }

        var link = await _linkResourcesRepository.GetByIdAsync(linkId);
        if (link == null)
        {
            throw new ArgumentException("Link not found.");
        }

        // Resolve the parent class
        var cls = await _repository.GetByIdAsync(link.ClassId);

        if (cls == null)
        {
            throw new ArgumentException("Parent class not found.");
        }

        // Only the course teacher may remove links
        var teacherId = cls.Participation?.CourseVariant?.Course?.TeacherId;
        if (teacherId is null || teacherId != userId)
        {
            return false;
        }

        await _linkResourcesRepository.DeleteAsync(linkId);
        return true;
    }

    public async Task<IEnumerable<GetClassLinkDTO>> GetClassLinksAsync(Guid classId)
    {
        return await _repository
            .GetByIdAsync(classId)
            .ContinueWith(task =>
            {
                var cls = task.Result;
                if (cls == null)
                {
                    throw new ArgumentException("Class not found.");
                }

                var links = cls.Links.Select(link => new GetClassLinkDTO
                {
                    Id = link.Id,
                    Path = link.Link,
                    IsMeeting = false,
                    CourseName = link.Class.Participation.CourseVariant.Course.Name ?? ""
                });

                links = cls.LinkToMeeting != null ? new[]
                        {
                            new GetClassLinkDTO
                            {
                                Id = Guid.Empty, 
                                Path = cls.LinkToMeeting, 
                                IsMeeting = true,
                                CourseName = cls.Participation.CourseVariant.Course.Name ?? ""
                            }
                        }
                        .Concat(links)
                    : links;

                return links;
            });
    }

    public async Task<IEnumerable<GetClassFileDTO>> GetClassFilesAsync(Guid classId)
    {
        return await _repository
            .GetByIdAsync(classId)
            .ContinueWith(task =>
            {
                var cls = task.Result;
                if (cls == null)
                {
                    throw new ArgumentException("Class not found.");
                }

                var files = cls.Files.Select(file => new GetClassFileDTO
                {
                    Id = file.Id,
                    Name = file.Name,
                    FilePath = file.Path,
                    AssociatedCourseName = cls.Participation.CourseVariant.Course.Name ?? "",
                    AssociatedClassDate = cls.StartTime
                });

                return files;
            });
    }

    public async Task<IEnumerable<GetExerciseDTO>> GetClassExercisesAsync(Guid classId)
    {
        return await _repository
            .GetByIdAsync(classId)
            .ContinueWith(task =>
            {
                var cls = task.Result;
                if (cls == null)
                {
                    throw new ArgumentException("Class not found.");
                }

                var exercises = cls.Exercises.Select(exercise => new GetExerciseDTO
                {
                    Id = exercise.Id,
                    Name = "Exercise " +
                           (cls.Participation.CourseVariant.Course.Name ?? "Unknown") +
                           " [" + cls.StartTime.ToString("yyyy-MM-dd") + "]",
                    CourseName = cls.Participation.CourseVariant.Course.Name ?? "",
                    Status = exercise.Status.ToString().ToLowerInvariant(),
                    Graded = exercise.Grade.HasValue,
                    Grade = exercise.Grade,
                    Comments = exercise.Comment ?? "",
                    Instruction = exercise.Instruction ?? ""
                });

                return exercises;
            });
    }

    public async Task<bool> AddClassForExistingParticipation(Guid studentId, Guid courseId, DateTime startTime)
    {
        if (studentId == Guid.Empty)
        {
            throw new ArgumentException("Invalid student id.", nameof(studentId));
        }

        if (courseId == Guid.Empty)
        {
            throw new ArgumentException("Invalid course id.", nameof(courseId));
        }

        // Resolve participation by composite key
        var participation = await _participationRepository.GetByIdAsync(studentId, courseId);
        if (participation == null)
        {
            Console.WriteLine("Participation not found for studentId: " + studentId + ", courseId: " + courseId);
            return false;
        }

        // Ensure the participation belongs to the student (redundant check but kept for safety)
        if (participation.UserId != studentId)
        {
            Console.WriteLine("Participation userId does not match studentId.");
            return false;
        }
        
        // Ensure teacher availability
        var teacher = participation.CourseVariant?.Course?.Teacher;
        if (teacher == null || teacher.Id == Guid.Empty)
        {
            Console.WriteLine("Teacher not found for the course.");
            return false;
        }

        var teacherAvailability = await _teacherRepository.GetTeacherAvailabilityAsync(teacher.Id);
        if (teacherAvailability == null || !teacherAvailability.Any())
        {
            Console.WriteLine("Teacher not found for the course.");
            return false;
        }

        var requestedDate = DateOnly.FromDateTime(startTime);
        var dayAvailability = teacherAvailability.FirstOrDefault(d => d.Day == requestedDate);
        if (dayAvailability == null || dayAvailability.Timeslots == null || !dayAvailability.Timeslots.Any())
        {
            Console.WriteLine("Teacher is not available on the requested date: " + requestedDate);
            return false;
        }

        var startTimeOnly = TimeOnly.FromDateTime(startTime);
        var isAvailable = dayAvailability.Timeslots.Any(ts =>
            startTimeOnly >= ts.TimeFrom && startTimeOnly < ts.TimeUntil);

        if (!isAvailable)
        {
            Console.WriteLine("Teacher is not available at the requested time: " + startTimeOnly);
            return false;
        }

        var cls = new Class(startTime)
        {
            UserId = studentId,
            Participation = participation,
            CourseVariantId = participation.CourseVariant?.Id ?? Guid.Empty
        };

        await _repository.AddAsync(cls);
        return true;
    }
}