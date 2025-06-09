using Erdmier.GigHero.Client.Shared.Assignments.Models.DTOs;
using Erdmier.GigHero.Client.Shared.Common.Interfaces;
using Erdmier.GigHero.Client.Shared.Gigs.Models.DTOs;
using Erdmier.GigHero.Domain.AssignmentAggregate;
using Erdmier.GigHero.Domain.AssignmentAggregate.Entities;
using Erdmier.GigHero.Domain.GigAggregate.ValueObjects;

namespace Erdmier.GigHero.Client.Shared.Assignments.Mappers;

public sealed class AssignmentMapper : IMapper<Assignment, AssignmentDto>
{
    private readonly IMapper<AssignmentId, AssignmentIdDto> _assignmentIdMapper;

    private readonly IMapper<GigId, GigIdDto> _gigIdMapper;

    private readonly IMapper<Payment, PaymentDto> _paymentMapper;

    private readonly IMapper<TimeEntry, TimeEntryDto> _timeEntryMapper;

    public AssignmentMapper(IMapper<AssignmentId, AssignmentIdDto> assignmentIdMapper,
                            IMapper<GigId, GigIdDto>               gigIdMapper,
                            IMapper<Payment, PaymentDto>           paymentMapper,
                            IMapper<TimeEntry, TimeEntryDto>       timeEntryMapper)
    {
        _assignmentIdMapper = assignmentIdMapper;
        _gigIdMapper        = gigIdMapper;
        _paymentMapper      = paymentMapper;
        _timeEntryMapper    = timeEntryMapper;
    }

    public AssignmentDto MapToDto(Assignment domain)
        => AssignmentDto.Create(_assignmentIdMapper.MapToDto((AssignmentId)domain.Id),
                                _gigIdMapper.MapToDto(domain.GigId),
                                domain.HourlyRate,
                                domain.IsComplete,
                                domain.Name,
                                domain.Uri,
                                domain.Payments.Select(_paymentMapper.MapToDto)
                                      .ToList(),
                                domain.TimeEntries.Select(_timeEntryMapper.MapToDto)
                                      .ToList());

    public Assignment MapToDomain(AssignmentDto dto)
        => Assignment.CreateFromDto(_assignmentIdMapper.MapToDomain(dto.Id),
                                    _gigIdMapper.MapToDomain(dto.GigId),
                                    dto.Name,
                                    dto.HourlyRate,
                                    dto.IsComplete,
                                    dto.Uri,
                                    dto.Payments.Select(_paymentMapper.MapToDomain)
                                       .ToList(),
                                    dto.TimeEntries.Select(_timeEntryMapper.MapToDomain)
                                       .ToList());
}
