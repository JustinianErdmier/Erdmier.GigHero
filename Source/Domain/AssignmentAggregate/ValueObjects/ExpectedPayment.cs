namespace Erdmier.GigHero.Domain.AssignmentAggregate.ValueObjects;

public sealed class ExpectedPayment : ValueObject
{
    private ExpectedPayment()
    { }

    private ExpectedPayment(decimal amount) => Amount = amount;

    public decimal Amount { get; init; }

    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Amount;
    }

    public static ExpectedPayment Create(decimal amount) => new(amount);

    public static ExpectedPayment Zero() => new();
}
