namespace e_learning_backend.Domain.Courses.ValueObjects;

public record CourseRate
{
    private decimal Amount { get; }

    private CourseRate(decimal amount)
    {
        if (amount <= 0)
        {
            throw new ArgumentException("Rate must be greater than zero.");
        }

        Amount = amount;
    }

    public CourseRate IncreaseByAmount(decimal amount)
    {
        if (amount <= 0)
        {
            throw new ArgumentException("Amount must be positive.");
        }

        return new CourseRate(Amount + amount);
    }

    public CourseRate IncreaseByPercentage(decimal percentage)
    {
        if (percentage <= 0)
        {
            throw new ArgumentException("Percentage must be positive.");
        }

        return new CourseRate(Amount * (1 + percentage / 100));
    }

    public static CourseRate Create(decimal amount) => new CourseRate(amount);
}