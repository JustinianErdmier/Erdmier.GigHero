namespace Erdmier.GigHero.Domain.JobAggregate.Interfaces;

public interface IJob
{
    public bool IsComplete { get; }

    public string Name { get; }

    public IReadOnlyList<Payment> Payments { get; }

    public IReadOnlyList<TimeEntry> TimeEntries { get; }

    public decimal TotalAmountEarned { get; }

    public TimeSpan TotalTimeWorked { get; }

    public string? Uri { get; }

    public bool AddPayment(Payment payment);

    public bool AddTimeEntry(TimeEntry timeEntry);

    public void MarkAsCompleted();
}
