namespace Erdmier.GigHero.Domain.GigAggregate.ValueObjects;

public sealed class GigId : AggregateRootId<Guid>
{
    private GigId(Guid value)
        : base(value)
    { }

    public static GigId Create(Guid value) => new(value);

    public static GigId CreateUnique() => new(Guid.CreateVersion7());
}
