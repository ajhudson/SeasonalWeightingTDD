namespace SeasonalWeighting.Lib
{
    public interface ISeasonalWeightingCalculator
    {
        decimal Estimate(int annualQty, int seasonalWeighting);
    }
}
