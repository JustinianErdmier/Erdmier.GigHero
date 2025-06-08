namespace Erdmier.GigHero.Domain.JobAggregate.Interfaces;

public interface IPaidHourlyAssignment : IAssignment
{
    public float HourlyRate { get; }
}
