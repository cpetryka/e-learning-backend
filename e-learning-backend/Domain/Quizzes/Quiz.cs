using e_learning_backend.Domain.Classes;
using e_learning_backend.Domain.Courses;

namespace e_learning_backend.Domain.Quizzes;

public class Quiz
{
    public Guid Id { get; private set; }
    public double? Score { get; private set; }
    public bool MultipleChoice { get; private set; }
    
    public Guid ClassId { get; private set; }
    public Class Class { get; private set; }
    
    private readonly HashSet<Question> _questions = new();
    public IReadOnlyCollection<Question> Questions => _questions;
    
    protected Quiz() { }
    
    public Quiz(Guid id, bool multipleChoice, Class singleClass)
    {
        Id = id;
        MultipleChoice = multipleChoice;
        Class = singleClass ?? throw new ArgumentNullException(nameof(singleClass), "Class cannot be null.");
        ClassId = singleClass.Id;
    }
    
    public Quiz(bool multipleChoice, Class singleClass) : this(Guid.NewGuid(), multipleChoice, singleClass) { }
    
    public void AddQuestion(Question question)
    {
        if (question == null)
        {
            throw new ArgumentNullException(nameof(question), "Question cannot be null.");
        }

        _questions.Add(question);
        question.AddQuiz(this);
    }
    
    public void RemoveQuestion(Question question)
    {
        if (question == null)
        {
            throw new ArgumentNullException(nameof(question), "Question cannot be null.");
        }

        if (!_questions.Remove(question))
        {
            throw new InvalidOperationException("Question is not associated with this quiz.");
        }
        
        question.RemoveQuiz(this);
    }
    
    public void SetScore(double score)
    {
        if (score < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(score), "Score cannot be negative.");
        }

        Score = score;
    }
}