namespace Erdmier.GigHero.Client.Shared.Assignments.Models.DTOs;

public sealed record TimeEntryStartDto(DateTimeOffset Time)
{
    public static TimeEntryStartDto Create(DateTimeOffset time) => new(time);
}
