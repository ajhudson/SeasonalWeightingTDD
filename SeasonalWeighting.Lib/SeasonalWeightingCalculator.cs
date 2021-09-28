using System;

namespace SeasonalWeighting.Lib
{
    public class SeasonalWeightingCalculator : ISeasonalWeightingCalculator
    {
        public decimal Estimate(int annualQty, int seasonalWeighting)
        {
            const int daysInYear = 365;

            int dailyUsage = annualQty / daysInYear;
            decimal seasonalWeightingMultiplier = seasonalWeighting / 100.0m;
            decimal dailyAnnualQuantityWithWeightingKwh = dailyUsage * (seasonalWeightingMultiplier + 1.0m);
            int daysInBillingPeriod = 31;
            decimal estimatedUsage = dailyAnnualQuantityWithWeightingKwh * daysInBillingPeriod;

            return estimatedUsage;
        }
    }
}
