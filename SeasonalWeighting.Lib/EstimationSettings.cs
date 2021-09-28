using System.Collections.Generic;

namespace SeasonalWeighting.Lib
{
    public class EstimationSettings
    {
        public int AnnualQuantity { get; set; }

        public List<BillingPeriodInfo> BillingPeriods { get; set; }
    }
}