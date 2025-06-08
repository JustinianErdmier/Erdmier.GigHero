namespace Erdmier.GigHero.Domain.JobAggregate.ValueObjects;

public sealed class TimeEntryId : EntityId<Guid>
{
    private TimeEntryId(Guid value)
        : base(value)
    { }

    public static TimeEntryId Create(Guid value) => new(value);

    public static TimeEntryId CreateUnique() => new(Guid.CreateVersion7());
}
