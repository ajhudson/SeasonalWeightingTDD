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

        [Test]
        public void ShouldCalcWhenSeasonalWeightingIsPercentageIncreaseOfAnnualQuantity()
        {
            // Arrange

            // Act
            int result = this._seasonalWeightingCalculator.CalculateSeasonalWeighting();

            // Assert
            result.ShouldBe(3720);
        }
    }
}