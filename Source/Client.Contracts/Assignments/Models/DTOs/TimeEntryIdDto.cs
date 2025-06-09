namespace Erdmier.GigHero.Client.Contracts.Assignments.Models.DTOs;

public sealed record TimeEntryIdDto(Guid Value)
{
    public static TimeEntryIdDto Create(Guid value) => new(value);
}
