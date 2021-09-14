using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeasonalWeighting.Lib
{
    public class SeasonalWeightingCalculator : ISeasonalWeightingCalculator
    {
        private const int DaysInYear = 365;

        public int CalculateEstimatedUsage(SeasonalWeightingCalcSettings settings)
        {
            int dailyUsage = settings.AnnualQuantity / DaysInYear;
            int seasonalWeighting = 20;
            decimal seasonalWeightingMultiplier = dailyUsage * (seasonalWeighting /;
            decimal dailyAnnualQuantityWithWeightingKwh = dailyUsage * (seasonalWeightingMultiplier + 1.0m);
            int daysInBillingPeriod = 31;
            decimal estimatedUsage = dailyAnnualQuantityWithWeightingKwh * daysInBillingPeriod;

            return 0;
        }
    }
}
