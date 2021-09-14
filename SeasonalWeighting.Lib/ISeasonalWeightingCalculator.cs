using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeasonalWeighting.Lib
{
    public interface ISeasonalWeightingCalculator
    {
        int CalculateSeasonalWeighting();
    }
}
