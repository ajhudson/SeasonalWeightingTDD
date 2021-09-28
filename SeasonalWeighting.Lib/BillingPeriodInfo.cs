using System;

namespace SeasonalWeighting.Lib
{
    public class BillingPeriodInfo
    {
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public int SeasonalWeighting { get; set; }
    }
}