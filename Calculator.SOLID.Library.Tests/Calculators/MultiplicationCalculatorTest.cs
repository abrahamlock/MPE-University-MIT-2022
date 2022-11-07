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
        private Mock<ICalculatorInputValidator> _calculatorInputValidator;

        [TestInitialize]
        public void Initialize()
        {
            _mocker = new AutoMocker();
            _multiplicationCalculator = _mocker.CreateInstance<MultiplicationCalculator>();
            _calculatorInputValidator = _mocker.GetMock<ICalculatorInputValidator>();
        }

        [TestMethod]
        public void Calculate_MultiplicationOfList_HappyPath()
        {
            //Arrange
            var inputList = "1,2,3";
            var exepectedResult = 6;

            //Act
            _multiplicationCalculator.Calculate(inputList);

            var actualResult = _multiplicationCalculator.GetCalulatedValue();

            //Assert
            Assert.AreEqual(exepectedResult, actualResult);

            //Arrange
            inputList = "6,9, 10,3";
            _multiplicationCalculator.Calculate(inputList);
            exepectedResult = 1620;

            actualResult = _multiplicationCalculator.GetCalulatedValue();

            Assert.AreEqual(exepectedResult, actualResult);

            _calculatorInputValidator.Verify();
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void Calculate_InvalidInputFormat_ThrowFormatException()
        {
            //Arrange
            var inputList = "*1 && 93 * *8";

            //Setup
            _calculatorInputValidator.Setup(x => x.IsContainInvalidInput(It.IsAny<Func<bool>>(), It.IsAny<Exception>())).Throws(new FormatException());

            //Act
            _multiplicationCalculator.Calculate(inputList);     
        }

        [TestMethod]
        public void Calculate_VerifyInputValidator_RanOnce()
        {
            //Arrange
            var inputList = "1,2";

            //Setup
            _calculatorInputValidator.Setup(x => x.IsContainInvalidInput(It.IsAny<Func<bool>>(), It.IsAny<Exception>())).Returns(true);
            _calculatorInputValidator.Verify(x => x.IsContainInvalidInput(It.IsAny<Func<bool>>(), It.IsAny<Exception>()), Times.Never);

            //Act
            _multiplicationCalculator.Calculate(inputList);

            //Assert
            _calculatorInputValidator.Verify(x => x.IsContainInvalidInput(It.IsAny<Func<bool>>(), It.IsAny<Exception>()), Times.Once);
        }
    }
}
