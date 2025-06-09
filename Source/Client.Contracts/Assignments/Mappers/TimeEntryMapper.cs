using Erdmier.GigHero.Domain.AssignmentAggregate.Entities;

namespace Erdmier.GigHero.Client.Contracts.Assignments.Mappers;

public sealed class TimeEntryMapper : IMapper<TimeEntry, TimeEntryDto>
{
    private readonly IMapper<TimeEntryEnd, TimeEntryEndDto> _timeEntryEndMapper;

    private readonly IMapper<TimeEntryId, TimeEntryIdDto> _timeEntryIdMapper;

    private readonly IMapper<TimeEntryStart, TimeEntryStartDto> _timeEntryStartMapper;

    public TimeEntryMapper(IMapper<TimeEntryEnd, TimeEntryEndDto>     timeEntryEndMapper,
                           IMapper<TimeEntryId, TimeEntryIdDto>       timeEntryIdMapper,
                           IMapper<TimeEntryStart, TimeEntryStartDto> timeEntryStartMapper)
    {
        _timeEntryEndMapper   = timeEntryEndMapper;
        _timeEntryIdMapper    = timeEntryIdMapper;
        _timeEntryStartMapper = timeEntryStartMapper;
    }

    public TimeEntryDto MapToDto(TimeEntry domain)
        => TimeEntryDto.Create(_timeEntryIdMapper.MapToDto(domain.Id),
                               _timeEntryStartMapper.MapToDto(domain.Start),
                               domain.End != null ? _timeEntryEndMapper.MapToDto(domain.End) : null);

    public TimeEntry MapToDomain(TimeEntryDto dto)
        => TimeEntry.CreateFromDto(_timeEntryIdMapper.MapToDomain(dto.Id),
                                   _timeEntryStartMapper.MapToDomain(dto.Start),
                                   dto.End != null ? _timeEntryEndMapper.MapToDomain(dto.End) : null);
}
