namespace SeasonalWeighting.Lib
{
    public interface ISeasonalWeightingCalculator
    {
        decimal CalculateEstimatedUsage(int annualQuantity, int seasonalWeighting);
    }
}
