namespace Erdmier.GigHero.Client.Contracts.Assignments.Mappers;

public sealed class TimeEntryEndMapper : IMapper<TimeEntryEnd, TimeEntryEndDto>
{
    public TimeEntryEndDto MapToDto(TimeEntryEnd domain) => TimeEntryEndDto.Create(domain.Time);

    public TimeEntryEnd MapToDomain(TimeEntryEndDto dto) => TimeEntryEnd.Create(dto.Time);
}
