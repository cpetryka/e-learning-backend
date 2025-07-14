namespace e_learning_backend.Domain.Quizzes;

public class Answer
{
    public Guid Id { get; set; }
    public string Content { get; set; }
    public bool IsCorrect { get; set; }
    
    private readonly HashSet<Question> _questions = new();
    public IReadOnlyCollection<Question> Questions => _questions;
    
    protected Answer() { }
    
    public Answer(Guid id, string content, bool isCorrect)
    {
        Id = id;
        Content = content ?? throw new ArgumentNullException(nameof(content), "Answer cannot be null or empty.");
        IsCorrect = isCorrect;
    }
    
    public Answer(string content, bool isCorrect) : this(Guid.NewGuid(), content, isCorrect) { }
    
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
            throw new InvalidOperationException("Question is not associated with this answer.");
        }
    }
}