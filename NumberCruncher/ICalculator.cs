using System.Collections.Generic;

namespace NumberCruncher
{
    public interface ICalculator
    {
        List<string> CalculateServiceListKeys { get; }

        void AddValue(int value);
        void AddValues(List<int> values);
        void AddValues(string valuesString);
        void ClearValues();
        int GetCalculateResult();
        void SetCalculateService(string serviceKey);
    }
}