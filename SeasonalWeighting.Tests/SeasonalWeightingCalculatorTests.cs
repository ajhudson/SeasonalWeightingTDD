using NUnit.Framework;
using SeasonalWeighting.Lib;
using Shouldly;

namespace SeasonalWeighting.Tests
{
    public class Tests
    {
        private ISeasonalWeightingCalculator _seasonalWeightingCalculator;

        [SetUp]
        public void Setup()
        {
            this._seasonalWeightingCalculator = new SeasonalWeightingCalculator();
        }

        /*
         * Scenario 1 Seasonal Weighting as a Percentage Increase of the Annual Quantity (AQ)
            • Bill period 1st January 2020 to 31st January 2020
            • Bill consists of estimated usage only
            • Annual consumption (AQ) is 36,500
            • January seasonal weighting is 20

            Calculation:
            • Daily usage is AQ / No of days in the year i.e. 36,500/365 = 100kWh
            • SW multiplier = 100*20% = 0.2
            • Daily AQ and daily SW = 100*1.2 = 120kWh
            • Estimated days in billing period = 31
            • Total estimated consumption for the period = 120*31 = 3,720
         */
        [Test]
        public void ShouldCalcWhenSeasonalWeightingIsPercentageIncreaseOfAnnualQuantity()
        {
            // Arrange
            var settings = new SeasonalWeightingCalcSettings
            {
                AnnualQuantity = 36500
            };

            // Act
            int result = this._seasonalWeightingCalculator.CalculateEstimatedUsage(settings);

            // Assert
            result.ShouldBe(3720);
        }
    }
}