using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberCruncher
{
    public class AppController : IAppController
    {
        private IServiceProvider _serviceProvider;
        private ICalculator _calculator;

        public AppController(IServiceProvider serviceProvider, ICalculator calculator)
        {

            _serviceProvider = serviceProvider;
            _calculator = calculator;
        }

        public void Run()
        {
            Console.WriteLine("Enter your values separated by a space.  Press <Enter> when finished.");
            var inputString = Console.ReadLine();
            _calculator.AddValues(inputString);
            
            var exitFlag = false;

            while (!exitFlag)
            {
                int strategyIndex = 1;
                var calculatorKeys = _calculator.CalculateServiceListKeys;
                foreach (var option in calculatorKeys)
                {
                    Console.WriteLine($"{strategyIndex++}: {option}");
                }

                Console.WriteLine("Select the operation you'd like to perform or <enter> to quit:");

                int selection = 0;
                if (int.TryParse(Console.ReadLine(), out selection))
                {
                    _calculator.SetCalculateService(calculatorKeys[selection - 1]);
                    var result = _calculator.GetCalculateResult();
                    Console.WriteLine("The result of your selected operation is:" + result);
                    Console.WriteLine("<enter> when ready");
                    Console.ReadLine();
                }
                else
                {
                    exitFlag = true;
                }
            } 
        }
    }
}
