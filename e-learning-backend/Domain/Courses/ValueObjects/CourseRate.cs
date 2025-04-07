namespace e_learning_backend.Domain.Courses.ValueObjects;

/// <summary>
///     Represents the monetary rate associated with a course.
/// </summary>
public record CourseRate
{
    public decimal Amount { get; }

    private CourseRate() {}

    public CourseRate(decimal amount)
    {
        if (amount <= 0)
        {
            throw new ArgumentException("Rate must be greater than zero.", nameof(amount));
        }

        Amount = amount;
    }

    /// <summary>
    ///     Returns a new <see cref="CourseRate"/> increased by a specific amount.
    /// </summary>
    /// <param name="amount">The amount to increase the rate by.</param>
    /// <returns>A new instance of <see cref="CourseRate"/> with the updated value.</returns>
    /// <exception cref="ArgumentException">Thrown when the amount is not positive.</exception>
    public CourseRate IncreaseByAmount(decimal amount)
    {
        if (amount <= 0)
        {
            throw new ArgumentException("Amount must be positive.", nameof(amount));
        }

        return new CourseRate(Amount + amount);
    }

    /// <summary>
    ///     Returns a new <see cref="CourseRate"/> increased by a percentage.
    /// </summary>
    /// <param name="percentage">The percentage to increase the rate by.</param>
    /// <returns>A new instance of <see cref="CourseRate"/> with the updated value.</returns>
    /// <exception cref="ArgumentException">Thrown when the percentage is not positive.</exception>
    public CourseRate IncreaseByPercentage(decimal percentage)
    {
        if (percentage <= 0)
        {
            throw new ArgumentException("Percentage must be positive.", nameof(percentage));
        }

        return new CourseRate(Amount * (1 + percentage / 100));
    }
}
