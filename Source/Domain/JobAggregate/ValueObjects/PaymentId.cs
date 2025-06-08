namespace Erdmier.GigHero.Domain.JobAggregate.ValueObjects;

public sealed class PaymentId : EntityId<Guid>
{
    private PaymentId(Guid value)
        : base(value)
    { }

    public static PaymentId Create(Guid value) => new(value);

    public static PaymentId CreateUnique() => new(Guid.CreateVersion7());
}
