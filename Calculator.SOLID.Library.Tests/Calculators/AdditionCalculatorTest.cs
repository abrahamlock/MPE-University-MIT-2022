using Calculator.SOLID.Library.Calculators;
using Calculator.SOLID.Library.Validator.Interface;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Moq.AutoMock;
using System;

namespace Calculator.SOLID.Library.Tests.Calculators
{
    [TestClass]
    public class AdditionCalculatorTest
    {
        private AutoMocker _mocker;
        private AdditionCalculator _additionCalculator;
        private Mock<ICalculatorInputValidator> _calculatorInputValidator;

        [TestInitialize]
        public void Initialize()
        {
            _mocker = new AutoMocker();
            _additionCalculator = _mocker.CreateInstance<AdditionCalculator>();
            _calculatorInputValidator = _mocker.GetMock<ICalculatorInputValidator>();
        }

        // [MethodUnderTest]_[Scenario]_[ExpectedResult] 
        [TestMethod]
        public void Calculate_AdditionOfList_HappyPath()
        {
            //Arrange
            var inputList = "1,2,3";
            var exepectedResult = 6;

            //Act
            _additionCalculator.Calculate(inputList);

            var actualResult = _additionCalculator.GetCalulatedValue();

            //Assert
            Assert.AreEqual(exepectedResult, actualResult);

            //Arrange
            inputList = "100,4, 77";
            _additionCalculator.Calculate(inputList);
            exepectedResult = 181;

            //Act
            actualResult = _additionCalculator.GetCalulatedValue();

            //Assert
            Assert.AreEqual(exepectedResult, actualResult);
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void Calculate_InvalidInputFormat_ThrowFormatException()
        {
            //Arrange
            var inputList = "*1,3";

            //Setup
            _calculatorInputValidator.Setup(x => x.IsContainInvalidInput(It.IsAny<Func<bool>>(), It.IsAny<Exception>())).Throws(new FormatException());

            //Act
            _additionCalculator.Calculate(inputList);
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
            _additionCalculator.Calculate(inputList);

            //Assert
            _calculatorInputValidator.Verify(x => x.IsContainInvalidInput(It.IsAny<Func<bool>>(), It.IsAny<Exception>()), Times.Once);
        }

    }
}
