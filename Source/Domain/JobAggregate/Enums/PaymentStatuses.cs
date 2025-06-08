namespace Erdmier.GigHero.Domain.JobAggregate.Enums;

public enum PaymentStatuses
{
    Unpaid,

    Pending,

    ReceivedInFull,

    ReceivedInPart,

    Cancelled,

    Failed
}
