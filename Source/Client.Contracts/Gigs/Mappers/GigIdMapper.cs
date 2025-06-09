using Erdmier.GigHero.Client.Contracts.Gigs.Models.DTOs;
using Erdmier.GigHero.Domain.Gig.ValueObjects;

namespace Erdmier.GigHero.Client.Contracts.Gigs.Mappers;

public sealed class GigIdMapper : IMapper<GigId, GigIdDto>
{
    public GigIdDto MapToDto(GigId domain) => GigIdDto.Create(domain.Value);

    public GigId MapToDomain(GigIdDto dto) => GigId.Create(dto.Value);
}
