namespace NumberCruncher
{
    public interface ICalculateService
    {
        string StrategyName { get; }
        int Calculate(int[] values);
    }
}