namespace Erdmier.GigHero.Client.Contracts.Assignments.Models.DTOs;

public sealed record TimeEntryDto(TimeEntryIdDto Id, TimeEntryStartDto Start, TimeEntryEndDto? End)
{
    public static TimeEntryDto Create(TimeEntryIdDto id, TimeEntryStartDto start, TimeEntryEndDto? end) => new(id, start, end);
}
