namespace Erdmier.GigHero.Domain.JobAggregate.ValueObjects;

public sealed class ActualPayment : ValueObject
{
    private ActualPayment()
    { }

    private ActualPayment(decimal amount) => Amount = amount;

    public decimal Amount { get; init; }

    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Amount;
    }

    public static ActualPayment Create(decimal amount) => new(amount);

    public static ActualPayment Zero() => new();
}
