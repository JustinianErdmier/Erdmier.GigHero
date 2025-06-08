namespace Erdmier.GigHero.Domain.AssignmentAggregate.ValueObjects;

public sealed class TimeEntryStart : ValueObject
{
    private TimeEntryStart()
    { }

    private TimeEntryStart(DateTimeOffset time) => Time = time;

    public DateTimeOffset Time { get; init; }

    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Time;
    }

    public static TimeEntryStart Create() => new();

    public static TimeEntryStart Create(DateTimeOffset time) => new(time);
}
