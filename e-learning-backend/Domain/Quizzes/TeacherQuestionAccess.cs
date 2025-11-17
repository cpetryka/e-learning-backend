using e_learning_backend.Domain.Users;

namespace e_learning_backend.Domain.Quizzes;

public class TeacherQuestionAccess
{
    public Guid TeacherId { get; set; }
    public User Teacher { get; set; }
    
    public Guid QuestionId { get; set; }
    public Question Question { get; set; }
    
    public bool Created { get; set; }
    
    protected TeacherQuestionAccess() { }

    public TeacherQuestionAccess(User teacher, Question question, bool created)
    {
        Teacher = teacher ?? throw new ArgumentNullException(nameof(teacher), "Teacher cannot be null.");
        TeacherId = teacher.Id;
        
        Question = question ?? throw new ArgumentNullException(nameof(question), "Question cannot be null.");
        QuestionId = question.Id;
        
        Created = created;
    }

    public TeacherQuestionAccess(Guid teacherId, Question question, bool created)
    {
        TeacherId = teacherId;
        
        Question = question ?? throw new ArgumentNullException(nameof(question), "Question cannot be null.");
        QuestionId = question.Id;
        
        Created = created;
    }
}