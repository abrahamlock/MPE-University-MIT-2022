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
            _divisionCalculator.Calculate("1,2");

            var exepectedResult = 0.5;
            var actualResult = _divisionCalculator.GetCalulatedValue();

            Assert.AreEqual(exepectedResult, actualResult);


            _divisionCalculator.Calculate("100,2, 10");

            var exepectedResult2 = 5;
            var actualResult2 = _divisionCalculator.GetCalulatedValue();

            Assert.AreEqual(exepectedResult2, actualResult2);

            _calculatorInputValidator.Verify();
        }


        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void Calculate_InvalidInputFormat_ThrowFormatException()
        {
            _divisionCalculator.Calculate("*1,3");
            _calculatorInputValidator.Verify(x => x.IsContainInvalidInput(It.IsAny<Func<bool>>(), It.IsAny<Exception>()), Times.Once);
        }

        [TestMethod]
        public void Calculate_VerifyInputValidator_RanMoreThan1()
        {
            _calculatorInputValidator.Verify(x => x.IsContainInvalidInput(It.IsAny<Func<bool>>(), It.IsAny<Exception>()), Times.Never);
            _calculatorInputValidator.Setup(x => x.IsContainInvalidInput(It.IsAny<Func<bool>>(), It.IsAny<Exception>())).Returns(true);

            _divisionCalculator.Calculate("1,2");

            _calculatorInputValidator.Verify(x => x.IsContainInvalidInput(It.IsAny<Func<bool>>(), It.IsAny<Exception>()), Times.AtLeastOnce);
        }

        [TestMethod]
        [ExpectedException(typeof(DivideByZeroException))]
        public void Calculate_DivideByZero_ThrowFormatException()
        {
            _calculatorInputValidator.Verify(x => x.IsContainInvalidInput(It.IsAny<Func<bool>>(), It.IsAny<Exception>()), Times.Never);
            _calculatorInputValidator.Setup(x => x.IsContainInvalidInput(It.IsAny<Func<bool>>(), It.IsAny<Exception>())).Throws(new DivideByZeroException());

            _divisionCalculator.Calculate(It.IsAny<string>());
        }
    }
}
