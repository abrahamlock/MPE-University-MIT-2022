using Calculator.NonSOLID.Library.Calculators;
using Calculator.NonSOLID.Library.ExtentionMethod;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator.NonSOLID.Library.Tests
{
    [TestClass]
    public class MultiplicationCalculatorTest
    {
        private MultiplicationCalculator _multiplicationCalculator;

        [TestInitialize]
        public void Initialize()
        {
            _multiplicationCalculator = new MultiplicationCalculator();
        }

        [TestMethod]
        public void Calculate_MultiplicationOfList_HappyPath()
        {
            var list = "1,2,3".ToIntList();
            _multiplicationCalculator.Calculate(list);

            var exepectedResult = 6;
            var actualResult = _multiplicationCalculator.Total;

            Assert.AreEqual(exepectedResult, actualResult);

            var list2 = "6,9, 10,3".ToIntList();
            _multiplicationCalculator.Calculate(list2);

            var exepectedResult2 = 1620;
            var actualResult2 = _multiplicationCalculator.Total;

            Assert.AreEqual(exepectedResult2, actualResult2);
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void Calculate_InvalidInputFormat_ThrowFormatException()
        {
            var list = "*1,2".ToIntList();
            _multiplicationCalculator.Calculate(list);
        }
    }
}
