namespace Erdmier.GigHero.Client.Contracts.Assignments.Models.DTOs;

public sealed record ActualPaymentDto(decimal Amount)
{
    public static ActualPaymentDto Zero() => new(Amount: 0);

    public static ActualPaymentDto Create(decimal amount) => new(amount);
}
