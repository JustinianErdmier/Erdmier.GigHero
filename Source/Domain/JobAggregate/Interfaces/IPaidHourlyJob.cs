namespace Erdmier.GigHero.Domain.JobAggregate.Interfaces;

public interface IPaidHourlyJob : IJob
{
    public float HourlyRate { get; }
}
