using Erdmier.GigHero.Client.Shared.Assignments.Models.DTOs;
using Erdmier.GigHero.Client.Shared.Common.Interfaces;
using Erdmier.GigHero.Domain.AssignmentAggregate.Entities;

namespace Erdmier.GigHero.Client.Shared.Assignments.Mappers;

public sealed class PaymentMapper : IMapper<Payment, PaymentDto>
{
    private readonly IMapper<ActualPayment, ActualPaymentDto> _actualPaymentMapper;

    private readonly IMapper<ExpectedPayment, ExpectedPaymentDto> _expectedPaymentMapper;

    private readonly IMapper<PaymentId, PaymentIdDto> _paymentIdMapper;


    public PaymentMapper(IMapper<ActualPayment, ActualPaymentDto>     actualPaymentMapper,
                         IMapper<ExpectedPayment, ExpectedPaymentDto> expectedPaymentMapper,
                         IMapper<PaymentId, PaymentIdDto>             paymentIdMapper)
    {
        _actualPaymentMapper   = actualPaymentMapper;
        _expectedPaymentMapper = expectedPaymentMapper;
        _paymentIdMapper       = paymentIdMapper;
    }

    public PaymentDto MapToDto(Payment domain)
        => PaymentDto.Create(_paymentIdMapper.MapToDto(domain.Id),
                             _actualPaymentMapper.MapToDto(domain.Actual),
                             _expectedPaymentMapper.MapToDto(domain.Expected),
                             domain.Status,
                             domain.StatusComment,
                             domain.PayoutDate);

    public Payment MapToDomain(PaymentDto dto)
        => Payment.CreateFromDto(_paymentIdMapper.MapToDomain(dto.Id),
                                 _actualPaymentMapper.MapToDomain(dto.Actual),
                                 _expectedPaymentMapper.MapToDomain(dto.Expected),
                                 dto.Status,
                                 dto.StatusComment,
                                 dto.PayoutDate);
}
