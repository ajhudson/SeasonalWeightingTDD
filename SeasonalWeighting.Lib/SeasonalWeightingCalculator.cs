using System;

namespace SeasonalWeighting.Lib
{
    public class SeasonalWeightingCalculator : ISeasonalWeightingCalculator
    {
        private const int DaysInYear = 365;

        public decimal CalculateEstimatedUsage(int annualQuantity, int seasonalWeighting)
        {
            int dailyUsage = annualQuantity / DaysInYear;
            decimal seasonalWeightingMultiplier = seasonalWeighting / 100.0m;
            decimal dailyAnnualQuantityWithWeightingKwh = dailyUsage * (seasonalWeightingMultiplier + 1.0m);
            int daysInBillingPeriod = 31;
            decimal estimatedUsage = dailyAnnualQuantityWithWeightingKwh * daysInBillingPeriod;

            return estimatedUsage;
        }
    }
}
