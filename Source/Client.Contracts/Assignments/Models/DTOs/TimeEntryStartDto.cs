namespace Erdmier.GigHero.Client.Contracts.Assignments.Models.DTOs;

public sealed record TimeEntryStartDto(DateTimeOffset Time)
{
    public static TimeEntryStartDto Create(DateTimeOffset time) => new(time);
}
