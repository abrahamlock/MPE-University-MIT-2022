﻿using Calculator.NonSOLID.Library.Calculators;
using Calculator.NonSOLID.Library.ExtentionMethod;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator.NonSOLID.Library.Tests
{
    [TestClass]
    public class AdditionCalculatorTest
    {
        private AdditionCalculator _additionCalculator;

        [TestInitialize]
        public void Initialize()
        {
            _additionCalculator = new AdditionCalculator();
        }

        [TestMethod]
        public void Calculate_AdditionOfList_HappyPath()
        {
            var list = "1,2,3".ToIntList();
            _additionCalculator.Calculate(list);

            var exepectedResult = 6;
            var actualResult = _additionCalculator.Total;

            Assert.AreEqual(exepectedResult, actualResult);
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void Calculate_InvalidInputFormat_ThrowFormatException()
        {
            var list = "*1,2".ToIntList();
            _additionCalculator.Calculate(list);
        }
    }
}
