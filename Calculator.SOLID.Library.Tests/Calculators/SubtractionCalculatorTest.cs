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
            //Arrange
            var inputList = "1,2,3";
            var exepectedResult = -4;

            //Act
            _subtractionCalculator.Calculate(inputList);

            var actualResult = _subtractionCalculator.GetCalulatedValue();

            //Assert
            Assert.AreEqual(exepectedResult, actualResult);

            //Arrange
            inputList = "100,4, 77";
            _subtractionCalculator.Calculate(inputList);
            exepectedResult = 19;

            //Act
            actualResult = _subtractionCalculator.GetCalulatedValue();

            //Assert
            Assert.AreEqual(exepectedResult, actualResult);
        }

        [TestMethod]
        public void Calculate_SubrationOfList_ExpectingNegativeValue()
        {
            //Arrange
            var inputList = "1,6,7,10";
            var exepectedResult = -22;

            //Act
            _subtractionCalculator.Calculate(inputList);

            var actualResult = _subtractionCalculator.GetCalulatedValue();

            //Assert
            Assert.AreEqual(exepectedResult, actualResult);
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
            _subtractionCalculator.Calculate(inputList);

            //Assert
            _calculatorInputValidator.Verify(x => x.IsContainInvalidInput(It.IsAny<Func<bool>>(), It.IsAny<Exception>()), Times.Once);
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void Calculate_InvalidInputFormat_ThrowFormatException()
        {
            //Arrange
            var inputList = "*1,3";

            //Setup
            _calculatorInputValidator.Setup(x => x.IsContainInvalidInput(It.IsAny<Func<bool>>(), It.IsAny<Exception>())).Returns(false);

            //Act
            _subtractionCalculator.Calculate(inputList);
        }
    }
}
