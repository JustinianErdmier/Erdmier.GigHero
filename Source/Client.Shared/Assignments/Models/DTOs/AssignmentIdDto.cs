namespace Erdmier.GigHero.Client.Shared.Assignments.Models.DTOs;

public sealed record AssignmentIdDto(Guid Value)
{
    public static AssignmentIdDto Create(Guid value) => new(value);
}
