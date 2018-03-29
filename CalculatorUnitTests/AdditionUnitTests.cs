using CalculatorLogic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CalculatorUnitTests
{
    [TestClass, TestCategory("Unit")]
    public class AdditionUnitTests
    {
        [TestMethod]
        [DataRow(1, 2, 3)]
        [DataRow(12, 18, 30)]
        [DataRow(-2, 4, 2)]
        [DataRow(0, 0, 0)]
        public void AdditionOperationSumsCorrectly(int number1, int number2, int expectedSum)
        {
            var additionCalculator = new Addition();
            var calculatedSum = additionCalculator.AddNumbers(number1, number2);

            Assert.AreEqual(expectedSum, calculatedSum);
        }

        [TestMethod]
        public void FailIsEnvironmentVariableSaysSo()
        {
            bool shouldFail = bool.Parse(Environment.GetEnvironmentVariable("FAILTEST") ?? "false");

            Assert.IsFalse(shouldFail);
        }
    }
}