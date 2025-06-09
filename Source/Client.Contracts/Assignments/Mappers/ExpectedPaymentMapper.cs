namespace Erdmier.GigHero.Client.Contracts.Assignments.Mappers;

public sealed class ExpectedPaymentMapper : IMapper<ExpectedPayment, ExpectedPaymentDto>
{
    public ExpectedPaymentDto MapToDto(ExpectedPayment domain) => ExpectedPaymentDto.Create(domain.Amount);

    public ExpectedPayment MapToDomain(ExpectedPaymentDto dto) => ExpectedPayment.Create(dto.Amount);
}
