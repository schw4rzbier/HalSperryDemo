using System;
using System.Linq;

namespace NumberCruncher
{
    /// <summary>
    ///  Find the average of all the input values
    /// </summary>
    public class AverageCalculateService : ICalculateService
    {
        public string StrategyName => "Average";

        public int Calculate(int[] values)
        {
            var average = values.Average();
            return Convert.ToInt32(average);
        }
    }
}
