namespace Erdmier.GigHero.Domain.AssignmentAggregate.ValueObjects;

public sealed class AssignmentId : AggregateRootId<Guid>
{
    private AssignmentId(Guid value)
        : base(value)
    { }

    public static AssignmentId Create(Guid value) => new(value);

    public static AssignmentId CreateUnique() => new(Guid.CreateVersion7());
}
