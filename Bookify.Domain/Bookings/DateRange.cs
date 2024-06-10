﻿namespace Bookify.Domain.Bookings;

public record DateRange
{
    private DateRange() { }

    public DateOnly Start { get; init; }
    public DateOnly End { get; init; }

    public int LengthInDays => End.DayNumber - Start.DayNumber;

    // factory method
    public static DateRange Create(DateOnly start, DateOnly end)
    {
        if (start > end)
        {
            throw new ApplicationException("end date precedes start date");
        }

        return new DateRange()
        {
            Start = start,
            End = end
        };
    }
}