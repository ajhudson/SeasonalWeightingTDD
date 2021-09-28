namespace SeasonalWeighting.Lib
{
    public interface ISeasonalWeightingCalculator
    {
        decimal Estimate(EstimationSettings estimationSettings);
    }
}
