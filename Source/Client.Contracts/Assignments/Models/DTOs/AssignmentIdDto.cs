namespace Erdmier.GigHero.Client.Contracts.Assignments.Models.DTOs;

public sealed record AssignmentIdDto(Guid Value)
{
    public static AssignmentIdDto Create(Guid value) => new(value);
}
