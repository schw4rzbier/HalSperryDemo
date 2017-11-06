using System.Linq;

namespace NumberCruncher
{
    /// <summary>
    /// Find the min value of the input values.
    /// </summary>
    public class MinCalculateService: ICalculateService
    {
        public string StrategyName => "Min";

        public int Calculate(int[] values)
        {
            return values.Min();
        }
    }
}