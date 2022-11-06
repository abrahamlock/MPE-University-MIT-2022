using Calculator.SOLID.Library.Calculators;
using Calculator.SOLID.Library.Validator.Interface;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Moq.AutoMock;
using System;

namespace Calculator.SOLID.Library.Tests.Calculators
{
    [TestClass]
    public class SubtractionCalculatorTest
    {
        private AutoMocker _mocker;
        private SubtractionCalculator _subtractionCalculator;
        private Mock<ICalculatorInputValidator> _calculatorInputValidator;

        [TestInitialize]
        public void Initialize()
        {
            _mocker = new AutoMocker();
            _subtractionCalculator = _mocker.CreateInstance<SubtractionCalculator>();
            _calculatorInputValidator = _mocker.GetMock<ICalculatorInputValidator>();
        }

        [TestMethod]
        public void Calculate_SubrationOfList_HappyPath()
        {
            _subtractionCalculator.Calculate("1,2,3");

            var exepectedResult = -4;
            var actualResult = _subtractionCalculator.GetCalulatedValue();

            Assert.AreEqual(exepectedResult, actualResult);


            _subtractionCalculator.Calculate("100,4, 77");

            var exepectedResult2 = 19;
            var actualResult2 = _subtractionCalculator.GetCalulatedValue();

            Assert.AreEqual(exepectedResult2, actualResult2);

            _calculatorInputValidator.Verify();
        }

        [TestMethod]
        public void Calculate_SubrationOfList_ExpectingNegativeValue()
        {
            _subtractionCalculator.Calculate("1,6,7,10");

            var exepectedResult = -22;
            var actualResult = _subtractionCalculator.GetCalulatedValue();

            Assert.AreEqual(exepectedResult, actualResult);
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void Calculate_InvalidInputFormat_ThrowFormatException()
        {
            _subtractionCalculator.Calculate("*1,3");
            _calculatorInputValidator.Verify(x => x.IsContainInvalidInput(It.IsAny<Func<bool>>(), It.IsAny<Exception>()), Times.Once);
        }
    }
}
