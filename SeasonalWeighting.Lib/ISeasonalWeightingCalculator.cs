using System.Threading.Tasks;

namespace SeasonalWeighting.Lib
{
    public interface ISeasonalWeightingCalculator
    {
        Task<decimal> EstimateAsync(EstimationSettings estimationSettings);
    }
}
