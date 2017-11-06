using NumberCruncher;
using NUnit.Framework;

namespace NumberCruncherTests
{
    [TestFixture]
    public class UnitTest1
    {
        [Test]
        public void BootStrapTest()
        {
            var bootstrap = new BootStrapper();
            var container = bootstrap.AppContainer;
            var appController = container.GetInstance<IAppController>();
            Assert.IsTrue(appController is AppController);
            var calculator = container.GetInstance<ICalculator>();
            Assert.IsTrue(calculator is Calculator);
        }

        [Test]
        public void CalculatorServicesTest()
        {
            var bootstrap = new BootStrapper();
            var container = bootstrap.AppContainer;
            var calculator = container.GetInstance<ICalculator>();
            Assert.IsTrue(calculator.CalculateServiceListKeys.Contains("Average"));
            Assert.IsTrue(calculator.CalculateServiceListKeys.Contains("Max"));
            Assert.IsTrue(calculator.CalculateServiceListKeys.Contains("Min"));
            Assert.IsTrue(calculator.CalculateServiceListKeys.Contains("Multiply by 6 then subtract 21"));
        }

        [Test]
        public void CalculationTest()
        {
            var bootstrap = new BootStrapper();
            var container = bootstrap.AppContainer;
            var calculator = container.GetInstance<ICalculator>();
            calculator.AddValues("1 2 3 4 5");
            calculator.SetCalculateService("Average");
            Assert.AreEqual(calculator.GetCalculateResult(), 3);

            calculator.SetCalculateService("Min");
            Assert.AreEqual(calculator.GetCalculateResult(), 1);

            calculator.SetCalculateService("Max");
            Assert.AreEqual(calculator.GetCalculateResult(), 5);

            calculator.SetCalculateService("Multiply by 6 then subtract 21");
            Assert.AreEqual(calculator.GetCalculateResult(), 69);
        }

        [Test]
        public void CalculationTest2()
        {
            var bootstrap = new BootStrapper();
            var container = bootstrap.AppContainer;
            var calculator = container.GetInstance<ICalculator>();
            calculator.AddValues("10 20 30 40 50");
            calculator.SetCalculateService("Average");
            Assert.AreEqual(calculator.GetCalculateResult(), 30);

            calculator.SetCalculateService("Min");
            Assert.AreEqual(calculator.GetCalculateResult(), 10);

            calculator.SetCalculateService("Max");
            Assert.AreEqual(calculator.GetCalculateResult(), 50);

            calculator.SetCalculateService("Multiply by 6 then subtract 21");
            Assert.AreEqual(calculator.GetCalculateResult(), 879);
        }

        [Test]
        public void CalculationReorderTest()
        {
            var bootstrap = new BootStrapper();
            var container = bootstrap.AppContainer;
            var calculator = container.GetInstance<ICalculator>();
            calculator.AddValues("5 3 4 2 1");
            calculator.SetCalculateService("Average");
            Assert.AreEqual(calculator.GetCalculateResult(), 3);

            calculator.SetCalculateService("Min");
            Assert.AreEqual(calculator.GetCalculateResult(), 1);

            calculator.SetCalculateService("Max");
            Assert.AreEqual(calculator.GetCalculateResult(), 5);

            calculator.SetCalculateService("Multiply by 6 then subtract 21");
            Assert.AreEqual(calculator.GetCalculateResult(), 69);
        }
    }
}
