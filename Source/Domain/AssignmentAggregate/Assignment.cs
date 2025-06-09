using Erdmier.GigHero.Domain.AssignmentAggregate.Entities;
using Erdmier.GigHero.Domain.AssignmentAggregate.Interfaces;
using Erdmier.GigHero.Domain.GigAggregate.ValueObjects;

namespace Erdmier.GigHero.Domain.AssignmentAggregate;

public sealed class Assignment : AggregateRoot<AssignmentId, Guid>, IPaidSetAmountAssignment, IPaidHourlyAssignment
{
    private readonly List<Payment> _payments = [];

    private readonly List<TimeEntry> _timeEntries = [];

    private Assignment()
    { }

    private Assignment(GigId gigId, string name, AssignmentId? id = null)
        : base(id ?? AssignmentId.CreateUnique())
    {
        GigId = gigId;
        Name  = name;
    }

    public GigId GigId { get; private init; } = null!;

    public float HourlyRate { get; private set; }

    public bool IsComplete { get; private set; }

    public string Name { get; private set; } = null!;

    public string? Uri { get; private set; }

    public IReadOnlyList<Payment> Payments => _payments.AsReadOnly();

    public IReadOnlyList<TimeEntry> TimeEntries => _timeEntries.AsReadOnly();

    public decimal TotalAmountEarned => _payments.Sum(x => x.Actual.Amount);

    public TimeSpan TotalTimeWorked => CalculateTotalTimeWorked();

    public bool AddPayment(Payment payment)
    {
        if (_payments.Contains(payment))
        {
            return false;
        }

        _payments.Add(payment);

        return true;
    }

    public bool AddTimeEntry(TimeEntry timeEntry)
    {
        // TODO: Design additional business logic later to determine if entries overlap.
        if (_timeEntries.Contains(timeEntry)
            || _timeEntries.Any(x => x.Start == timeEntry.Start))
        {
            return false;
        }

        _timeEntries.Add(timeEntry);

        return true;
    }

    public decimal CalculateActualHourlyAveragePay() => _payments.Sum(x => x.Actual.Amount) / (decimal)TotalTimeWorked.TotalHours;

    public decimal CalculateExpectedHourlyAveragePay() => _payments.Sum(x => x.Expected.Amount) / (decimal)TotalTimeWorked.TotalHours;

    public void MarkAsCompleted() => IsComplete = true;

    public void UpdateHourlyRate(float hourlyRate) => HourlyRate = hourlyRate;

    public void UpdateName(string name) => Name = name;

    public void UpdateUri(string uri) => Uri = uri;

    private TimeSpan CalculateTotalTimeWorked()
        => _timeEntries.Where(x => x.End is not null)
                       .Aggregate(TimeSpan.Zero, (current, timeEntry) => current + (timeEntry.End!.Time - timeEntry.Start.Time));

    public static Assignment Create(GigId gigId, string name) => new(gigId, name);

    public static Assignment CreateFromDto(AssignmentId             id,
                                           GigId                    gigId,
                                           string                   name,
                                           float                    hourlyRate,
                                           bool                     isComplete,
                                           string?                  uri,
                                           IReadOnlyList<Payment>   payments,
                                           IReadOnlyList<TimeEntry> timeEntries)
    {
        Assignment assignment = new(gigId, name, id)
        {
            HourlyRate = hourlyRate,
            IsComplete = isComplete,
            Uri        = uri
        };

        foreach (Payment payment in payments)
        {
            assignment.AddPayment(payment);
        }

        foreach (TimeEntry timeEntry in timeEntries)
        {
            assignment.AddTimeEntry(timeEntry);
        }

        return assignment;
    }
}
