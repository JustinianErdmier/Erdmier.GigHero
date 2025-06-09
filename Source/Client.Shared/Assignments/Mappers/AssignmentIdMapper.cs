using Erdmier.GigHero.Client.Shared.Assignments.Models.DTOs;
using Erdmier.GigHero.Client.Shared.Common.Interfaces;

namespace Erdmier.GigHero.Client.Shared.Assignments.Mappers;

public sealed class AssignmentIdMapper : IMapper<AssignmentId, AssignmentIdDto>
{
    public AssignmentIdDto MapToDto(AssignmentId domain) => AssignmentIdDto.Create(domain.Value);

    public AssignmentId MapToDomain(AssignmentIdDto dto) => AssignmentId.Create(dto.Value);
}
