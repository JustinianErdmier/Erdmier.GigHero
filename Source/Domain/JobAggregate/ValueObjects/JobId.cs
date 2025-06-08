namespace Erdmier.GigHero.Domain.JobAggregate.ValueObjects;

public sealed class JobId : AggregateRootId<Guid>
{
    private JobId(Guid value)
        : base(value)
    { }

    public static JobId Create(Guid value) => new(value);

    public static JobId CreateUnique() => new(Guid.CreateVersion7());
}
