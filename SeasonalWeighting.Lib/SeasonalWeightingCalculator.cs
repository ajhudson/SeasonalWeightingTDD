using System;

namespace SeasonalWeighting.Lib
{
    public class SeasonalWeightingCalculator : ISeasonalWeightingCalculator
    {
        private const int DaysInYear = 365;

        public decimal CalculateEstimatedUsage(int annualQuantity, int seasonalWeighting)
        {
            throw new NotImplementedException();
        }
    }
}
