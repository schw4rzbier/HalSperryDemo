using NumberCruncher;
using NUnit.Framework;
using StructureMap;

namespace NumberCruncherTests
{
    [TestFixture]
    public class NumberCruncherTest
    {
        private ICalculator _calculator;
        private IAppController _appController;
        private Container _container;

        [OneTimeSetUp]
        public void Init()
        {
            var bootstrap = new BootStrapper();
            _container = bootstrap.AppContainer;
            _appController = _container.GetInstance<IAppController>();
            _calculator = _container.GetInstance<ICalculator>();
        }

        [Test]
        public void BootStrapTest()
        {
            Assert.IsTrue(_appController is AppController);
            Assert.IsTrue(_calculator is Calculator);
        }

        [Test]
        public void CalculatorServicesTest()
        {
            Assert.IsTrue(_calculator.CalculateServiceListKeys.Contains("Average"));
            Assert.IsTrue(_calculator.CalculateServiceListKeys.Contains("Max"));
            Assert.IsTrue(_calculator.CalculateServiceListKeys.Contains("Min"));
            Assert.IsTrue(_calculator.CalculateServiceListKeys.Contains("Multiply by 6 then subtract 21"));
        }

        [Test]
        public void CalculationTest()
        {
            _calculator.ClearValues();
            _calculator.AddValues("1 2 3 4 5");
            _calculator.SetCalculateService("Average");
            Assert.AreEqual(_calculator.GetCalculateResult(), 3);

            _calculator.SetCalculateService("Min");
            Assert.AreEqual(_calculator.GetCalculateResult(), 1);

            _calculator.SetCalculateService("Max");
            Assert.AreEqual(_calculator.GetCalculateResult(), 5);

            _calculator.SetCalculateService("Multiply by 6 then subtract 21");
            Assert.AreEqual(_calculator.GetCalculateResult(), 69);
        }

        [Test]
        public void CalculationTest2()
        {
            _calculator.ClearValues();
            _calculator.AddValues("10 20 30 40 50");
            _calculator.SetCalculateService("Average");
            Assert.AreEqual(_calculator.GetCalculateResult(), 30);

            _calculator.SetCalculateService("Min");
            Assert.AreEqual(_calculator.GetCalculateResult(), 10);

            _calculator.SetCalculateService("Max");
            Assert.AreEqual(_calculator.GetCalculateResult(), 50);

            _calculator.SetCalculateService("Multiply by 6 then subtract 21");
            Assert.AreEqual(_calculator.GetCalculateResult(), 879);
        }

        [Test]
        public void CalculationReorderTest()
        {
            _calculator.ClearValues();
            _calculator.AddValues("5 3 4 2 1");
            _calculator.SetCalculateService("Average");
            Assert.AreEqual(_calculator.GetCalculateResult(), 3);

            _calculator.SetCalculateService("Min");
            Assert.AreEqual(_calculator.GetCalculateResult(), 1);

            _calculator.SetCalculateService("Max");
            Assert.AreEqual(_calculator.GetCalculateResult(), 5);

            _calculator.SetCalculateService("Multiply by 6 then subtract 21");
            Assert.AreEqual(_calculator.GetCalculateResult(), 69);
        }
    }
}
