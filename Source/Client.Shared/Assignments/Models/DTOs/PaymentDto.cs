using Erdmier.GigHero.Domain.AssignmentAggregate.Enums;

namespace Erdmier.GigHero.Client.Shared.Assignments.Models.DTOs;

public sealed record PaymentDto(PaymentIdDto       Id,
                                ActualPaymentDto   Actual,
                                ExpectedPaymentDto Expected,
                                PaymentStatuses    Status,
                                string?            StatusComment,
                                DateTimeOffset?    PayoutDate)
{
    public static PaymentDto Create(PaymentIdDto       id,
                                    ActualPaymentDto   actualPayment,
                                    ExpectedPaymentDto expectedPayment,
                                    PaymentStatuses    status,
                                    string?            statusComment,
                                    DateTimeOffset?    payoutDate)
        => new(id, actualPayment, expectedPayment, status, statusComment, payoutDate);
}
