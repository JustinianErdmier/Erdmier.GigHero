namespace Erdmier.GigHero.Client.Shared.Assignments.Models.DTOs;

public sealed record TimeEntryEndDto(DateTimeOffset Time)
{
    public static TimeEntryEndDto Create(DateTimeOffset time) => new(time);
}
