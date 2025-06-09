using Erdmier.GigHero.Client.Shared.Assignments.Models.DTOs;
using Erdmier.GigHero.Client.Shared.Common.Interfaces;

namespace Erdmier.GigHero.Client.Shared.Assignments.Mappers;

public sealed class ExpectedPaymentMapper : IMapper<ExpectedPayment, ExpectedPaymentDto>
{
    public ExpectedPaymentDto MapToDto(ExpectedPayment domain) => ExpectedPaymentDto.Create(domain.Amount);

    public ExpectedPayment MapToDomain(ExpectedPaymentDto dto) => ExpectedPayment.Create(dto.Amount);
}
