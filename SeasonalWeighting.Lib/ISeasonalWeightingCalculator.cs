namespace SeasonalWeighting.Lib
{
    public interface ISeasonalWeightingCalculator
    {
        decimal CalculateEstimatedUsage(int annualConsumption, int seasonalWeighting);
    }
}
