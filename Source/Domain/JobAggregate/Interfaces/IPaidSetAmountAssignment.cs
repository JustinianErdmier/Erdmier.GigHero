namespace Erdmier.GigHero.Domain.JobAggregate.Interfaces;

public interface IPaidSetAmountAssignment : IAssignment
{
    public decimal CalculateActualHourlyAveragePay();

    public decimal CalculateExpectedHourlyAveragePay();
}
