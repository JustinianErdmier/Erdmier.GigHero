using Erdmier.GigHero.Client.Shared.Assignments.Models.DTOs;
using Erdmier.GigHero.Client.Shared.Common.Interfaces;

namespace Erdmier.GigHero.Client.Shared.Assignments.Mappers;

public sealed class TimeEntryEndMapper : IMapper<TimeEntryEnd, TimeEntryEndDto>
{
    public TimeEntryEndDto MapToDto(TimeEntryEnd domain) => TimeEntryEndDto.Create(domain.Time);

    public TimeEntryEnd MapToDomain(TimeEntryEndDto dto) => TimeEntryEnd.Create(dto.Time);
}
