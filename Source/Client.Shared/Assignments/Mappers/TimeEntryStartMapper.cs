using Erdmier.GigHero.Client.Shared.Assignments.Models.DTOs;
using Erdmier.GigHero.Client.Shared.Common.Interfaces;

namespace Erdmier.GigHero.Client.Shared.Assignments.Mappers;

public sealed class TimeEntryStartMapper : IMapper<TimeEntryStart, TimeEntryStartDto>
{
    public TimeEntryStartDto MapToDto(TimeEntryStart domain) => TimeEntryStartDto.Create(domain.Time);

    public TimeEntryStart MapToDomain(TimeEntryStartDto dto) => TimeEntryStart.Create(dto.Time);
}
