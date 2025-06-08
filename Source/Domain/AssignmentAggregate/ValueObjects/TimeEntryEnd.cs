namespace Erdmier.GigHero.Domain.AssignmentAggregate.ValueObjects;

public sealed class TimeEntryEnd : ValueObject
{
    private TimeEntryEnd()
    { }

    private TimeEntryEnd(DateTimeOffset time) => Time = time;

    public DateTimeOffset Time { get; init; }

    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Time;
    }

    public static TimeEntryEnd Create() => new();

    public static TimeEntryEnd Create(DateTimeOffset time) => new(time);
}
