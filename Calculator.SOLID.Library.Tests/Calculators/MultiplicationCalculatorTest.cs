using Calculator.SOLID.Library.Calculators;
using Calculator.SOLID.Library.Validator.Interface;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Moq.AutoMock;
using System;

namespace Calculator.SOLID.Library.Tests.Calculators
{
    [TestClass]
    public class MultiplicationCalculatorTest
    {
        private AutoMocker _mocker;
        private MultiplicationCalculator _multiplicationCalculator;
        private Mock<ICalculatorInputValidator> calculatorInputValidator;

        [TestInitialize]
        public void Initialize()
        {
            _mocker = new AutoMocker();
            _multiplicationCalculator = _mocker.CreateInstance<MultiplicationCalculator>();
            calculatorInputValidator = _mocker.GetMock<ICalculatorInputValidator>();
        }

        [TestMethod]
        public void Calculate_MultiplicationOfList_HappyPath()
        {
            _multiplicationCalculator.Calculate("1,2,3");

            var exepectedResult = 6;
            var actualResult = _multiplicationCalculator.GetCalulatedValue();

            Assert.AreEqual(exepectedResult, actualResult);


            _multiplicationCalculator.Calculate("6,9, 10,3");

            var exepectedResult2 = 1620;
            var actualResult2 = _multiplicationCalculator.GetCalulatedValue();

            Assert.AreEqual(exepectedResult2, actualResult2);

            calculatorInputValidator.Verify();
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void Calculate_InvalidInputFormat_ThrowFormatException()
        {
            _multiplicationCalculator.Calculate("1&&93**8");
            calculatorInputValidator.Verify(x => x.IsContainInvalidInput(It.IsAny<Func<bool>>(), It.IsAny<Exception>()), Times.Once);
        }
    }
}
