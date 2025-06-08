namespace Erdmier.GigHero.Domain.AssignmentAggregate.Interfaces;

public interface IPaidHourlyAssignment : IAssignment
{
    public float HourlyRate { get; }
}
