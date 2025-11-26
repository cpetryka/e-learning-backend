using e_learning_backend.Domain.Classes;
using e_learning_backend.Domain.Courses;

namespace e_learning_backend.Domain.Quizzes;

public class Quiz
{
    public Guid Id { get; private set; }
    public string Title { get; private set; }
    public double? Score { get; set; }
    public bool MultipleChoice { get; private set; }
    
    public Guid ClassId { get; private set; }
    public Class Class { get; private set; }
    
    private readonly HashSet<Question> _questions = new();
    public IReadOnlyCollection<Question> Questions => _questions;
    
    protected Quiz() { }
    
    public Quiz(Guid id, string title, bool multipleChoice, Class singleClass)
    {
        Id = id;
        Title = title ?? throw new ArgumentNullException(nameof(title), "Title cannot be null.");
        MultipleChoice = multipleChoice;
        Class = singleClass ?? throw new ArgumentNullException(nameof(singleClass), "Class cannot be null.");
        ClassId = singleClass.Id;
    }
    
    public Quiz(string title, bool multipleChoice, Class singleClass) : this(Guid.NewGuid(), title, multipleChoice, singleClass) { }
    
    public void AddQuestion(Question question)
    {
        if (question == null)
        {
            throw new ArgumentNullException(nameof(question), "Question cannot be null.");
        }
        
        // Avoid duplicates based on Id
        if (_questions.Any(q => q.Id == question.Id))
            return;

        _questions.Add(question);
        
        if (!question.Quizzes.Contains(this))
        {
            question.AddQuiz(this);
        }
    }
    
    public void RemoveQuestion(Question question)
    {
        if (question == null)
        {
            throw new ArgumentNullException(nameof(question), "Question cannot be null.");
        }

        // Find the actual instance stored in this quiz by Id
        var existing = _questions.FirstOrDefault(q => q.Id == question.Id);
        if (existing == null)
        {
            throw new InvalidOperationException("Question is not associated with this quiz.");
        }

        // Remove from this side
        _questions.Remove(existing);
        
        // Try to remove the back-reference on the question side but don't fail if it's already inconsistent
        try
        {
            existing.RemoveQuiz(this);
        }
        catch { } // Ignore
    }
    
    public void SetScore(double score)
    {
        if (score < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(score), "Score cannot be negative.");
        }

        Score = score;
    }
    
    public void SetTitle(string title)
    {
        if (string.IsNullOrWhiteSpace(title))
        {
            throw new ArgumentException("Title cannot be empty.", nameof(title));
        }

        Title = title;
    }
}