namespace Erdmier.GigHero.Client.Contracts.Assignments.Mappers;

public sealed class TimeEntryStartMapper : IMapper<TimeEntryStart, TimeEntryStartDto>
{
    public TimeEntryStartDto MapToDto(TimeEntryStart domain) => TimeEntryStartDto.Create(domain.Time);

    public TimeEntryStart MapToDomain(TimeEntryStartDto dto) => TimeEntryStart.Create(dto.Time);
}
