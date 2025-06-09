using Erdmier.GigHero.Client.Shared.Assignments.Models.DTOs;
using Erdmier.GigHero.Client.Shared.Common.Interfaces;

namespace Erdmier.GigHero.Client.Shared.Assignments.Mappers;

public sealed class TimeEntryIdMapper : IMapper<TimeEntryId, TimeEntryIdDto>
{
    public TimeEntryIdDto MapToDto(TimeEntryId domain) => TimeEntryIdDto.Create(domain.Value);

    public TimeEntryId MapToDomain(TimeEntryIdDto dto) => TimeEntryId.Create(dto.Value);
}
