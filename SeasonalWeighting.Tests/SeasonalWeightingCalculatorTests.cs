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
        public void ShouldCalcWhenSeasonalWeightingIsPercentageIncreaseOfAnnualQuantity()
        {
            // Arrange
            int annualQty = 36500;
            int seasonalWeighting = 20;

            // Act
            decimal result = this._seasonalWeightingCalculator.Estimate(annualQty, seasonalWeighting);

            // Assert
            result.ShouldBe(3720.0m);
        }
    }
}