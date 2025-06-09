namespace Erdmier.GigHero.Client.Shared.Assignments.Models.DTOs;

public sealed record TimeEntryIdDto(Guid Value)
{
    public static TimeEntryIdDto Create(Guid value) => new(value);
}
