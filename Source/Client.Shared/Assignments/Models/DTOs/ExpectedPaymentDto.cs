namespace Erdmier.GigHero.Client.Shared.Assignments.Models.DTOs;

public sealed record ExpectedPaymentDto(decimal Amount)
{
    public static ExpectedPaymentDto Create(decimal amount) => new(amount);

    public static ExpectedPaymentDto Zero() => new(Amount: 0);
}
