using e_learning_backend.Domain.Users;

namespace e_learning_backend.Domain.Quizzes;

public class Question
{
    public Guid Id { get; set; }
    public string Content { get; set; }
    
    private readonly HashSet<QuestionCategory> _categories = new();
    public IReadOnlyCollection<QuestionCategory> Categories => _categories;
    
    private readonly HashSet<Answer> _answers = new();
    public IReadOnlyCollection<Answer> Answers => _answers;
    
    private readonly HashSet<TeacherQuestionAccess> _accesses = new();
    public IReadOnlyCollection<TeacherQuestionAccess> Accesses => _accesses;
    
    private readonly HashSet<Quiz> _quizzes = new();
    public IReadOnlyCollection<Quiz> Quizzes => _quizzes;
    
    protected Question() { }
    
    public Question(Guid id, string content)
    {
        Id = id;
        Content = content ?? throw new ArgumentNullException(nameof(content), "Question content cannot be null or empty.");
    }
    
    public Question(string content) : this(Guid.NewGuid(), content) { }
    
    public void AddCategory(QuestionCategory category)
    {
        if (category == null)
        {
            throw new ArgumentNullException(nameof(category), "Category cannot be null.");
        }

        _categories.Add(category);
        category.AddQuestion(this);
    }

    public void AddCategory(Guid categoryId)
    {
        
    }
    
    public void RemoveCategory(QuestionCategory category)
    {
        if (category == null)
        {
            throw new ArgumentNullException(nameof(category), "Category cannot be null.");
        }

        if (!_categories.Remove(category))
        {
            throw new InvalidOperationException("Category is not associated with this question.");
        }
        
        category.RemoveQuestion(this);
    }
    
    public void AddAnswer(Answer answer)
    {
        if (answer == null)
        {
            throw new ArgumentNullException(nameof(answer), "Answer cannot be null.");
        }

        _answers.Add(answer);
        answer.AddQuestion(this);
    }
    
    public void RemoveAnswer(Answer answer)
    {
        if (answer == null)
        {
            throw new ArgumentNullException(nameof(answer), "Answer cannot be null.");
        }

        if (!_answers.Remove(answer))
        {
            throw new InvalidOperationException("Answer is not associated with this question.");
        }
        
        answer.RemoveQuestion(this);
    }
    
    public void AddAccess(TeacherQuestionAccess access)
    {
        if (access == null)
        {
            throw new ArgumentNullException(nameof(access), "Access cannot be null.");
        }

        _accesses.Add(access);
        access.Question = this;
    }

    public void AddAccess(Guid teacherId, bool created)
    {
        var access = new TeacherQuestionAccess
        (
            teacherId: teacherId,
            question: this,
            created: created
        );
        
        _accesses.Add(access);
    }
    
    public void RemoveAccess(TeacherQuestionAccess access)
    {
        if (access == null)
        {
            throw new ArgumentNullException(nameof(access), "Access cannot be null.");
        }

        if (!_accesses.Remove(access))
        {
            throw new InvalidOperationException("Access is not associated with this question.");
        }
        
        access.Question = null; // Clear the reference to this question
    }
    
    public void AddQuiz(Quiz quiz)
    {
        if (quiz == null)
        {
            throw new ArgumentNullException(nameof(quiz), "Quiz cannot be null.");
        }

        _quizzes.Add(quiz);
        quiz.AddQuestion(this);
    }
    
    public void RemoveQuiz(Quiz quiz)
    {
        if (quiz == null)
        {
            throw new ArgumentNullException(nameof(quiz), "Quiz cannot be null.");
        }

        if (!_quizzes.Remove(quiz))
        {
            throw new InvalidOperationException("Quiz is not associated with this question.");
        }
        
        quiz.RemoveQuestion(this);
    }
}