using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberCruncher
{
    public class Calculator : ICalculator
    {
        private readonly ICalculateServiceFactory _calculateServiceFactory;
        private readonly List<string> _calculateServiceKeys;
        private List<int> _values;
        private ICalculateService _calculateService;
        
        public Calculator(ICalculateServiceFactory calculateServiceFactory)
        {
            _calculateServiceFactory = calculateServiceFactory;
            _calculateServiceKeys = _calculateServiceFactory.ServiceKeys;
            _values = new List<int>();
        }

        public List<string> CalculateServiceListKeys => _calculateServiceKeys;

        public void ClearValues()
        {
            _values.Clear();
        }

        public void AddValues(List<int> values)
        {
            _values.AddRange(values);
        }

        public void AddValues(string valuesString)
        {
            var unconvertedStringArray = valuesString.Split(' ');

            List<int> valueList;
            try
            {
                valueList = unconvertedStringArray.ToList().ConvertAll(int.Parse);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Invalid input list.");
                Console.ReadLine();
                throw;
            }
            _values.AddRange(valueList);
        }

        public void AddValue(int value)
        {
            _values.Add(value);
        }

        public void SetCalculateService(string serviceKey)
        {
            _calculateService = _calculateServiceFactory.GetCalculateService(serviceKey);
        }

        public int GetCalculateResult()
        {
            return _calculateService.Calculate(_values.ToArray());
        }
        
    }
}
