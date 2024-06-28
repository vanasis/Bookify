using Bookify.Application.Abstractions.Clock;

namespace Bookify.Infrastructure.Clock;

internal sealed class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow
    {
        get { return DateTime.UtcNow; }
    }
}