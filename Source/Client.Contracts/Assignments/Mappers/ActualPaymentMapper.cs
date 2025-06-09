namespace Erdmier.GigHero.Client.Contracts.Assignments.Mappers;

public sealed class ActualPaymentMapper : IMapper<AssignmentId, AssignmentIdDto>
{
    public AssignmentIdDto MapToDto(AssignmentId domain) => AssignmentIdDto.Create(domain.Value);

    public AssignmentId MapToDomain(AssignmentIdDto dto) => AssignmentId.Create(dto.Value);
}
