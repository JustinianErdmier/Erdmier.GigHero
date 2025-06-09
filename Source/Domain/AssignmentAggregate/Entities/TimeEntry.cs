namespace Erdmier.GigHero.Domain.AssignmentAggregate.Entities;

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

    public TimeEntryEnd? End { get; private set; }

    public TimeEntryStart Start { get; private set; } = TimeEntryStart.Create();

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

    public static TimeEntry CreateFromDto(TimeEntryId id, TimeEntryStart startTime, TimeEntryEnd? endTime)
        => endTime == null ? new TimeEntry(startTime, id) : new TimeEntry(startTime, endTime, id);
}
