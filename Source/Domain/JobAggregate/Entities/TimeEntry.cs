namespace Erdmier.GigHero.Domain.JobAggregate.Entities;

public sealed class TimeEntry : Entity<TimeEntryId>
{
    private TimeEntry()
    { }

    private TimeEntry(TimeEntryStart startTime, TimeEntryId? id = null)
        : base(id ?? TimeEntryId.CreateUnique())
        => Start = startTime;

    private TimeEntry(TimeEntryStart startTime, TimeEntryEnd endTime, TimeEntryId? id = null)
        : base(id ?? TimeEntryId.CreateUnique())
        => (Start, End) = (startTime, endTime);

    public TimeEntryStart Start { get; private set; } = TimeEntryStart.Create();

    public TimeEntryEnd? End { get; private set; }

    public TimeSpan TimeWorked => End is null ? Start.Time.Subtract(DateTimeOffset.Now) : End.Time.Subtract(Start.Time);

    public bool UpdateStartTime(TimeEntryStart startTime)
    {
        if (End is not null
            && End.Time < startTime.Time)
        {
            return false;
        }

        Start = startTime;

        return true;
    }

    public bool UpdateEndTime(TimeEntryEnd endTime)
    {
        if (Start.Time > endTime.Time)
        {
            return false;
        }

        End = endTime;

        return true;
    }

    public static TimeEntry Create(TimeEntryStart start) => new(start);

    public static TimeEntry Create(TimeEntryStart startTime, TimeEntryEnd endTime) => new(startTime, endTime);
}
