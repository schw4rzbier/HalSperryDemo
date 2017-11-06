using System.Linq;

namespace NumberCruncher
{
    /// <summary>
    /// Sum all the input values then multiply by 6 then subtract 21
    /// </summary>
    public class NovelCalculateService : ICalculateService
    {
        public string StrategyName => "Multiply by 6 then subtract 21";

        public int Calculate(int[] values)
        {
            var sum = values.Sum();
            return sum * 6 - 21;
        }
    }
}
