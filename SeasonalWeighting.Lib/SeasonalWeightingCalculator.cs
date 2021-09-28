using System;
using System.Linq;

namespace SeasonalWeighting.Lib
{
    public class SeasonalWeightingCalculator : ISeasonalWeightingCalculator
    {
        public decimal Estimate(EstimationSettings estimationSettings)
        {
            const int daysInYear = 365;

            int dailyUsage = estimationSettings.AnnualQuantity / daysInYear;
            decimal estimatedUsage = estimationSettings.BillingPeriods.Select(bp => this.GetEstimatedConsumption(dailyUsage, bp)).Sum();

            return estimatedUsage;
        }

        private decimal GetEstimatedConsumption(int dailyUsage, BillingPeriodInfo billingPeriodInfo)
        {
            decimal seasonalWeightingMultiplier = billingPeriodInfo.SeasonalWeighting / 100.0m;
            decimal dailyAnnualQtyWithWeightKwh = dailyUsage * (seasonalWeightingMultiplier + 1.0m);
            TimeSpan billingPeriod = billingPeriodInfo.EndDate - billingPeriodInfo.StartDate;
            int billingPeriodDays = billingPeriod.Days + 1; // need at add one so last billing day is inclusive
            decimal estimatedUsage = dailyAnnualQtyWithWeightKwh * billingPeriodDays;

            return estimatedUsage;
        }
    }
}
