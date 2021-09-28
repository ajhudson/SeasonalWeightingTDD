using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeasonalWeighting.Lib
{
    public class SeasonalWeightingCalculator : ISeasonalWeightingCalculator
    {
        private readonly IRepository _repository;

        public SeasonalWeightingCalculator(IRepository repository)
        {
            this._repository = repository;
        }

        public async Task<decimal> EstimateAsync(EstimationSettings estimationSettings)
        {
            const int daysInYear = 365;

            int dailyUsage = estimationSettings.AnnualQuantity / daysInYear;
            IEnumerable<Task<decimal>> getEstimatedUsageTasks = estimationSettings.BillingPeriods.Select(async bp => await this.GetEstimatedConsumptionAsync(dailyUsage, bp));
            decimal[] estimatedUsages = await Task.WhenAll(getEstimatedUsageTasks);
            decimal estimatedUsage = estimatedUsages.Sum();

            return estimatedUsage;
        }

        private async Task<decimal> GetEstimatedConsumptionAsync(int dailyUsage, BillingPeriodInfo billingPeriodInfo)
        {
            int monthNum = billingPeriodInfo.StartDate.Month;
            int seasonalWeighting = await this._repository.GetSeasonalWeightingForMonthAsync(monthNum);
            decimal seasonalWeightingMultiplier = seasonalWeighting / 100.0m;
            decimal dailyAnnualQtyWithWeightKwh = dailyUsage * (seasonalWeightingMultiplier + 1.0m);
            TimeSpan billingPeriod = billingPeriodInfo.EndDate - billingPeriodInfo.StartDate;
            int billingPeriodDays = billingPeriod.Days + 1; // need at add one so last billing day is inclusive
            decimal estimatedUsage = dailyAnnualQtyWithWeightKwh * billingPeriodDays;

            return estimatedUsage;
        }
    }
}
