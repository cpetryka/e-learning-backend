using e_learning_backend.Domain.Quizzes;

namespace e_learning_backend.Infrastructure.Persistence.Repositories;

public interface ITeacherQuestionAccessRepository
{
    Task<TeacherQuestionAccess?> GetByIdAsync(Guid teacherId, Guid questionId);

    Task<IEnumerable<TeacherQuestionAccess>> GetAllAsync();

    Task AddAsync(TeacherQuestionAccess access);

    Task UpdateAsync(TeacherQuestionAccess access);

    Task DeleteAsync(Guid teacherId, Guid questionId);

    Task<IEnumerable<TeacherQuestionAccess>> GetByTeacherIdAsync(Guid teacherId);

    Task<IEnumerable<TeacherQuestionAccess>> GetByQuestionIdAsync(Guid questionId);
}