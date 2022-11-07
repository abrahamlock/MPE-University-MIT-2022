using Calculator.NonSOLID.Library.Calculators;
using Calculator.NonSOLID.Library.ExtentionMethod;
using Calculator.NonSOLID.Library.Validator;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator.NonSOLID.Library.Tests
{
    [TestClass]
    public class DivisionCalculatorTest
    {
        private DivisionCalculator _divisionCalculator;
        private CalculatorInputValidator _validator;

        [TestInitialize]
        public void Initialize()
        {
            _validator = new CalculatorInputValidator();
            _divisionCalculator = new DivisionCalculator(_validator);
        }

        [TestMethod]
        public void Calculate_DivisionOfList_HappyPath()
        {
            var list = "1,2".ToIntList();
            _divisionCalculator.Calculate(list);

            var exepectedResult = 0.5;
            var actualResult = _divisionCalculator.Total;

            Assert.AreEqual(exepectedResult, actualResult);

            var list2 = "100,2, 10".ToIntList();
            _divisionCalculator.Calculate(list2);

            var exepectedResult2 = 5;
            var actualResult2 = _divisionCalculator.Total;

            Assert.AreEqual(exepectedResult2, actualResult2);
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void Calculate_InvalidInputFormat_ThrowFormatException()
        {
            var list = "*1,3".ToIntList();
            _divisionCalculator.Calculate(list);
         }

        [TestMethod]
        [ExpectedException(typeof(DivideByZeroException))]
        public void Calculate_DivideByZero_ThrowFormatException()
        {
            var list = "1,0".ToIntList();
            _divisionCalculator.Calculate(list);
        }
    }
}
