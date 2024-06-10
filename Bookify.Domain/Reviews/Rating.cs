using Bookify.Domain.Abstractions;

namespace Bookify.Domain.Reviews;

public record Rating
{
    private Rating(int value)
    {
        Value = value;
    }

    public int Value { get; init; }

    // Factory method
    public static Result<Rating> Create(int value)
    {
        if (value < 1 || value > 5)
        {
            return Result.Failure<Rating>(RatingErrors.Invalid);
        }

        return new Rating(value);
    }
}