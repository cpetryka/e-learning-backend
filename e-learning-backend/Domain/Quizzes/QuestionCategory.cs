using e_learning_backend.Domain.Users;

namespace e_learning_backend.Domain.Quizzes;

public class QuestionCategory
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    
    public Guid TeacherId { get; set; }
    public User Teacher { get; set; }
    
    private readonly HashSet<Question> _questions = new();
    public IReadOnlyCollection<Question> Questions => _questions;
    
    protected QuestionCategory() {}

    public QuestionCategory(Guid id, string name, string description, User teacher)
    {
        Id = id;
        Name = name ?? throw new ArgumentNullException(nameof(name), "Category name cannot be null or empty.");
        Description = description ?? throw new ArgumentNullException(nameof(description), "Category description cannot be null or empty.");
        Teacher = teacher ?? throw new ArgumentNullException(nameof(teacher), "Teacher cannot be null.");
        TeacherId = teacher.Id;
    }
    
    public QuestionCategory(string name, string description, User teacher) 
        : this(Guid.NewGuid(), name, description, teacher) { }
    
    public void AddQuestion(Question question) 
    {
        if (question == null)
        {
            throw new ArgumentNullException(nameof(question), "Question cannot be null.");
        }

        _questions.Add(question);
    }
    
    public void RemoveQuestion(Question question) 
    {
        if (question == null)
        {
            throw new ArgumentNullException(nameof(question), "Question cannot be null.");
        }

        if (!_questions.Remove(question))
        {
            throw new InvalidOperationException("Question is not associated with this category.");
        }
    }
}