namespace Erdmier.GigHero.Client.Contracts.Assignments.Mappers;

public sealed class ActualPaymentMapper : IMapper<ActualPayment, ActualPaymentDto>
{
    public ActualPaymentDto MapToDto(ActualPayment domain) => ActualPaymentDto.Create(domain.Amount);

    public ActualPayment MapToDomain(ActualPaymentDto dto) => ActualPayment.Create(dto.Amount);
}
