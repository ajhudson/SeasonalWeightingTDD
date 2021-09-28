using System;
using System.Collections.Generic;
using NUnit.Framework;
using SeasonalWeighting.Lib;
using Shouldly;

namespace SeasonalWeighting.Tests
{
    [TestFixture]
    public class Tests
    {
        private ISeasonalWeightingCalculator _seasonalWeightingCalculator;

        [SetUp]
        public void Setup()
        {
            this._seasonalWeightingCalculator = new SeasonalWeightingCalculator();
        }

        [Test]
        [TestCase(20, 3720)]
        [TestCase(-20, 2480)]
        public void ShouldReturnCorrectResultForScenario1And2(int seasonalWeighting, decimal expectedResult)
        {
            // Arrange
            var januaryBillingInfo = new BillingPeriodInfo
            {
                StartDate = new DateTime(2021, 1, 1),
                EndDate = new DateTime(2021, 1, 31),
                SeasonalWeighting = seasonalWeighting
            };

            var estimationSettings = new EstimationSettings
            {
                AnnualQuantity = 36500,
                BillingPeriods = new List<BillingPeriodInfo> { januaryBillingInfo }
            };

            // Act
            decimal result = this._seasonalWeightingCalculator.Estimate(estimationSettings);

            // Assert
            result.ShouldBe(expectedResult);
        }

        [Test]
        public void ShouldReturnCorrectResultForScenario3()
        {
            // Arrange
            var januaryBillingInfo = new BillingPeriodInfo
            {
                StartDate = new DateTime(2021, 1, 1),
                EndDate = new DateTime(2021, 1, 31),
                SeasonalWeighting = 20
            };

            var februaryBillingInfo = new BillingPeriodInfo
            {
                StartDate = new DateTime(2021, 2, 1),
                EndDate = new DateTime(2021, 2, 28),
                SeasonalWeighting = 22
            };

            var estimationSettings = new EstimationSettings
            {
                AnnualQuantity = 36500,
                BillingPeriods = new List<BillingPeriodInfo>
                {
                    januaryBillingInfo,
                    februaryBillingInfo
                }
            };

            // Act
            decimal result = this._seasonalWeightingCalculator.Estimate(estimationSettings);

            // Assert
            result.ShouldBe(7258.0m);
        }
    }
}