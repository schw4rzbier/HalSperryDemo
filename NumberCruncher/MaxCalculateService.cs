using System.Linq;

namespace NumberCruncher
{
    /// <summary>
    /// Find the max value of the input values
    /// </summary>
    public class MaxCalculateService : ICalculateService
    {
        public string StrategyName => "Max";

        public int Calculate(int[] values)
        {
            return values.Max();
        }
    }
}
