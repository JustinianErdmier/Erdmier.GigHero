using Erdmier.GigHero.Client.Shared.Assignments.Models.DTOs;
using Erdmier.GigHero.Client.Shared.Common.Interfaces;

namespace Erdmier.GigHero.Client.Shared.Assignments.Mappers;

public sealed class PaymentIdMapper : IMapper<PaymentId, PaymentIdDto>
{
    public PaymentIdDto MapToDto(PaymentId domain) => PaymentIdDto.Create(domain.Value);

    public PaymentId MapToDomain(PaymentIdDto dto) => PaymentId.Create(dto.Value);
}
