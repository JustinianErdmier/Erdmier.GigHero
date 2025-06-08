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

    public static bool operator ==(TimeEntryEnd? left, DateTimeOffset? right)
    {
        if (left is null
            || right is null)
        {
            return false;
        }

        return left.Time == right;
    }

    public static bool operator !=(TimeEntryEnd? left, DateTimeOffset? right) => !(left == right);

    public static TimeEntryEnd Create() => new();

    public static TimeEntryEnd Create(DateTimeOffset time) => new(time);
}
