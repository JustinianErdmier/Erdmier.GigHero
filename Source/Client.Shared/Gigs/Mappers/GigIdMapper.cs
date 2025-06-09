using Erdmier.GigHero.Client.Shared.Common.Interfaces;
using Erdmier.GigHero.Client.Shared.Gigs.Models.DTOs;
using Erdmier.GigHero.Domain.GigAggregate.ValueObjects;

namespace Erdmier.GigHero.Client.Shared.Gigs.Mappers;

public sealed class GigIdMapper : IMapper<GigId, GigIdDto>
{
    public GigIdDto MapToDto(GigId domain) => GigIdDto.Create(domain.Value);

    public GigId MapToDomain(GigIdDto dto) => GigId.Create(dto.Value);
}
