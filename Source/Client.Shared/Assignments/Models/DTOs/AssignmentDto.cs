using Erdmier.GigHero.Client.Shared.Gigs.Models.DTOs;

namespace Erdmier.GigHero.Client.Shared.Assignments.Models.DTOs;

public sealed record AssignmentDto(AssignmentIdDto             Id,
                                   GigIdDto                    GigId,
                                   float                       HourlyRate,
                                   bool                        IsComplete,
                                   string                      Name,
                                   string?                     Uri,
                                   IReadOnlyList<PaymentDto>   Payments,
                                   IReadOnlyList<TimeEntryDto> TimeEntries)
{
    public static AssignmentDto Create(AssignmentIdDto             id,
                                       GigIdDto                    gigId,
                                       float                       hourlyRate,
                                       bool                        isComplete,
                                       string                      name,
                                       string?                     uri,
                                       IReadOnlyList<PaymentDto>   payments,
                                       IReadOnlyList<TimeEntryDto> timeEntries)
        => new(id, gigId, hourlyRate, isComplete, name, uri, payments, timeEntries);
}
