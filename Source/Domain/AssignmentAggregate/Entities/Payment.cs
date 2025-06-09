using Erdmier.GigHero.Domain.AssignmentAggregate.Enums;

namespace Erdmier.GigHero.Domain.AssignmentAggregate.Entities;

public sealed class Payment : Entity<PaymentId>
{
    private Payment()
    { }

    private Payment(ExpectedPayment expected, PaymentStatuses status, PaymentId? id = null)
        : base(id ?? PaymentId.CreateUnique())
    {
        Expected = expected;
        Status   = status;
    }

    private Payment(ActualPayment actual, ExpectedPayment expected, PaymentStatuses status, PaymentId? id = null)
        : base(id ?? PaymentId.CreateUnique())
    {
        Actual   = actual;
        Expected = expected;
        Status   = status;
    }

    public ActualPayment Actual { get; private set; } = ActualPayment.Zero();

    public ExpectedPayment Expected { get; private set; } = ExpectedPayment.Zero();

    public PaymentStatuses Status { get; private set; } = PaymentStatuses.Unpaid;

    public string? StatusComment { get; private set; }

    public DateTimeOffset? PayoutDate { get; private set; }

    public void MarkAsPending(ActualPayment actualPayment, string? comment)
    {
        Actual        = actualPayment;
        Status        = PaymentStatuses.Pending;
        StatusComment = comment;
    }

    public bool MarkAsReceivedInFull(ActualPayment actualPayment, string? comment)
    {
        if (actualPayment.Amount < Expected.Amount)
        {
            return false;
        }

        Actual        = actualPayment;
        Status        = PaymentStatuses.ReceivedInFull;
        StatusComment = comment;

        return true;
    }

    public bool MarkAsReceivedInPart(ActualPayment actualPayment, string? comment)
    {
        if (actualPayment.Amount >= Expected.Amount)
        {
            return false;
        }

        Actual        = actualPayment;
        Status        = PaymentStatuses.ReceivedInPart;
        StatusComment = comment;

        return true;
    }

    public void MarkAsCancelled(string? comment)
    {
        Actual        = ActualPayment.Zero();
        Status        = PaymentStatuses.Cancelled;
        StatusComment = comment;
    }

    public void MarkAsFailed(string? comment)
    {
        Actual        = ActualPayment.Zero();
        Status        = PaymentStatuses.Failed;
        StatusComment = comment;
    }

    public void UpdateActual(ActualPayment actualPay) => Actual = actualPay;

    public void UpdateExpected(ExpectedPayment expectedPay) => Expected = expectedPay;

    public void UpdateStatus(PaymentStatuses status) => Status = status;

    public void UpdateStatusComment(string? comment) => StatusComment = comment;

    public void UpdatePayoutDate(DateTimeOffset? date) => PayoutDate = date;

    public static Payment Create() => new();

    public static Payment Create(ExpectedPayment expectedPay) => new(expectedPay, PaymentStatuses.Unpaid);

    public static Payment Create(ActualPayment actualPay, ExpectedPayment expectedPay) => new(actualPay, expectedPay, PaymentStatuses.Unpaid);

    public static Payment CreateFromDto(PaymentId       id,
                                        ActualPayment   actualPay,
                                        ExpectedPayment expectedPay,
                                        PaymentStatuses status,
                                        string?         statusComment,
                                        DateTimeOffset? payoutDate)
        => new(actualPay, expectedPay, status, id)
        {
            StatusComment = statusComment,
            PayoutDate    = payoutDate
        };
}
