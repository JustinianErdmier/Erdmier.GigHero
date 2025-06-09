using Erdmier.GigHero.Client.Shared.Assignments.Models.DTOs;
using Erdmier.GigHero.Client.Shared.Common.Interfaces;

namespace Erdmier.GigHero.Client.Shared.Assignments.Mappers;

public sealed class ActualPaymentMapper : IMapper<ActualPayment, ActualPaymentDto>
{
    public ActualPaymentDto MapToDto(ActualPayment domain) => ActualPaymentDto.Create(domain.Amount);

    public ActualPayment MapToDomain(ActualPaymentDto dto) => ActualPayment.Create(dto.Amount);
}
