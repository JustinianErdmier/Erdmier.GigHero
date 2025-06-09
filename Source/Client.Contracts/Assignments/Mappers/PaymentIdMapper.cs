namespace Erdmier.GigHero.Client.Contracts.Assignments.Mappers;

public sealed class PaymentIdMapper : IMapper<PaymentId, PaymentIdDto>
{
    public PaymentIdDto MapToDto(PaymentId domain) => PaymentIdDto.Create(domain.Value);

    public PaymentId MapToDomain(PaymentIdDto dto) => PaymentId.Create(dto.Value);
}
