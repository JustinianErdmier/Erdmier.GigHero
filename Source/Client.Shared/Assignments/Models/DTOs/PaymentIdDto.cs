namespace Erdmier.GigHero.Client.Shared.Assignments.Models.DTOs;

public sealed record PaymentIdDto(Guid Value)
{
    public static PaymentIdDto Create(Guid value) => new(value);
}
