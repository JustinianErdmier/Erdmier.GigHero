using Erdmier.GigHero.Client.Contracts.Gigs.Models.DTOs;
using Erdmier.GigHero.Domain.Gig;
using Erdmier.GigHero.Domain.Gig.ValueObjects;

namespace Erdmier.GigHero.Client.Contracts.Gigs.Mappers;

public sealed class GigMapper : IMapper<Gig, GigDto>
{
    private readonly IMapper<AssignmentId, AssignmentIdDto> _assignmentIdMapper;

    private readonly IMapper<GigId, GigIdDto> _gigIdMapper;

    public GigMapper(IMapper<AssignmentId, AssignmentIdDto> assignmentIdMapper, IMapper<GigId, GigIdDto> gigIdMapper)
    {
        _assignmentIdMapper = assignmentIdMapper;
        _gigIdMapper        = gigIdMapper;
    }

    public GigDto MapToDto(Gig domain)
        => GigDto.Create(_gigIdMapper.MapToDto((GigId)domain.Id),
                         domain.Name,
                         domain.WebsiteUrl,
                         domain.UserId,
                         domain.AssignmentIds.Select(_assignmentIdMapper.MapToDto)
                               .ToList());

    public Gig MapToDomain(GigDto dto)
        => Gig.CreateFromDto(_gigIdMapper.MapToDomain(dto.Id),
                             dto.Name,
                             dto.UserId,
                             dto.WebsiteUrl,
                             dto.AssignmentIds.Select(_assignmentIdMapper.MapToDomain)
                                .ToList());
}
