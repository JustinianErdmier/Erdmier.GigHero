namespace Erdmier.GigHero.Client.Contracts.Assignments.Models.DTOs;

public sealed record TimeEntryEndDto(DateTimeOffset Time)
{
    public static TimeEntryEndDto Create(DateTimeOffset time) => new(time);
}
