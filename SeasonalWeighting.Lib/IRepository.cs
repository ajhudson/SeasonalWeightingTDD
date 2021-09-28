using System.Threading.Tasks;

namespace SeasonalWeighting.Lib
{
    public interface IRepository
    {
        Task<int> GetSeasonalWeightingForMonthAsync(int monthNumber);
    }
}