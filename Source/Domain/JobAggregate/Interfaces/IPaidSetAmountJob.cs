namespace Erdmier.GigHero.Domain.JobAggregate.Interfaces;

public interface IPaidSetAmountJob : IJob
{
    public decimal CalculateActualHourlyAveragePay();

    public decimal CalculateExpectedHourlyAveragePay();
}
