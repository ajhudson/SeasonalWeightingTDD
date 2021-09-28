using System;
using System.Linq;

namespace SeasonalWeighting.Lib
{
    public class SeasonalWeightingCalculator : ISeasonalWeightingCalculator
    {
        public decimal Estimate(EstimationSettings estimationSettings)
        {
            const int daysInYear = 365;

            int seasonalWeighting = estimationSettings.BillingPeriods.First().SeasonalWeighting;
            int dailyUsage = estimationSettings.AnnualQuantity / daysInYear;
            decimal seasonalWeightingMultiplier = seasonalWeighting / 100.0m;
            decimal dailyAnnualQuantityWithWeightingKwh = dailyUsage * (seasonalWeightingMultiplier + 1.0m);
            int daysInBillingPeriod = 31;
            decimal estimatedUsage = dailyAnnualQuantityWithWeightingKwh * daysInBillingPeriod;

            return estimatedUsage;
        }
    }
}
