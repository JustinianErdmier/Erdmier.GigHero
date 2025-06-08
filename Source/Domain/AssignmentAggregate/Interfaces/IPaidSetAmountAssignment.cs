namespace Erdmier.GigHero.Domain.AssignmentAggregate.Interfaces;

public interface IPaidSetAmountAssignment : IAssignment
{
    public decimal CalculateActualHourlyAveragePay();

    public decimal CalculateExpectedHourlyAveragePay();
}
