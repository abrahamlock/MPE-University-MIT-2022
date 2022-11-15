using Calculator.SOLID.Library.Calculators;
using Calculator.SOLID.Library.Validator.Interface;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Moq.AutoMock;
using System;

namespace Calculator.SOLID.Library.Tests.Calculators
{
    [TestClass]
    public class DivisionCalculatorTest
    {
        private AutoMocker _mocker;
        private DivisionCalculator _divisionCalculator;
        private Mock<ICalculatorInputValidator> _calculatorInputValidator;

        [TestInitialize]
        public void Initialize()
        {
            _mocker = new AutoMocker();
            _divisionCalculator = _mocker.CreateInstance<DivisionCalculator>();
            _calculatorInputValidator = _mocker.GetMock<ICalculatorInputValidator>();
        }

        [TestMethod]
        public void Calculate_DivisionOfList_HappyPath()
        {
            //Arrange
            var inputList = "1,2";
            var exepectedResult = 0.5;

            //Act
            _divisionCalculator.Calculate(inputList);

            var actualResult = _divisionCalculator.GetCalulatedValue();

            //Assert
            Assert.AreEqual(exepectedResult, actualResult);

            //Arrange
            inputList = "100,2, 10";
            _divisionCalculator.Calculate(inputList);
            exepectedResult = 5;

            //Act
            actualResult = _divisionCalculator.GetCalulatedValue();

            //Assert
            Assert.AreEqual(exepectedResult, actualResult);
            _calculatorInputValidator.Verify();
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
            _divisionCalculator.Calculate(inputList);
        }

        [TestMethod]
        public void Calculate_VerifyInputValidator_RanOnce()
        {
            //Arrange
            var inputList = "1,2";

            //Setup
            _calculatorInputValidator.Setup(x => x.IsContainInvalidInput(It.IsAny<Func<bool>>(), It.IsAny<Exception>())).
                Returns(true);
            _calculatorInputValidator.Verify(x => x.IsContainInvalidInput(It.IsAny<Func<bool>>(), It.IsAny<Exception>()), Times.Never);

            //Act
            _divisionCalculator.Calculate(inputList);

            //Assert
            _calculatorInputValidator.Verify(x => x.IsContainInvalidInput(It.IsAny<Func<bool>>(), It.IsAny<Exception>()), Times.Once);
        }

        [TestMethod]
        public void Calculate_DivideByZero_ThrowDivideByZeroException()
        {
            //Arrange
            var inputList = "1,0";

            //Setup
            _calculatorInputValidator.Setup(x => x.IsContainInvalidInput(It.IsAny<Func<bool>>(), It.IsAny<Exception>()))
                .Throws(new DivideByZeroException());
            _calculatorInputValidator.Verify(x => x.IsContainInvalidInput(It.IsAny<Func<bool>>(), It.IsAny<Exception>()), Times.Never);
           
            //Act
            try
            {
                _divisionCalculator.Calculate(inputList);
            }
            catch (DivideByZeroException)
            {
                _calculatorInputValidator.Verify(x => x.IsContainInvalidInput(It.IsAny<Func<bool>>(), It.IsAny<Exception>()), Times.Once);
            }
        }
    }
}
