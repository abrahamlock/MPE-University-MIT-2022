using Calculator.NonSOLID.Library.Calculators;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator.NonSOLID.Library.Tests
{
    [TestClass]
    public class SubtractionCalculatorTest
    {
        private SubtractionCalculator _substrationCalculator;

        [TestInitialize]
        public void Initialize()
        {
            _substrationCalculator = new SubtractionCalculator();
        }

        [TestMethod]
        public void AdditionCalculator_CalculateAdditionOfList_HappyPath()
        {
            var list ="1,2,3".ToIntergerList();
            _substrationCalculator.Calculate(list);

            var exepectedResult = -4;
            var actualResult = _substrationCalculator.Total;

            Assert.AreEqual(exepectedResult, actualResult);
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void AdditionCalculator_InvalidInputFormat_ThrowFormatException()
        {
            var list = "*1,2".ToIntergerList();
            _substrationCalculator.Calculate(list);
        }
    }
}
