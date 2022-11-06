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
            _additionCalculator.Calculate("1,2,3");

            var exepectedResult = 6;
            var actualResult = _additionCalculator.GetCalulatedValue();

            Assert.AreEqual(exepectedResult, actualResult);


            _additionCalculator.Calculate("100,4, 77");

            var exepectedResult2 = 181;
            var actualResult2 = _additionCalculator.GetCalulatedValue();

            Assert.AreEqual(exepectedResult2, actualResult2);
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void Calculate_InvalidInputFormat_ThrowFormatException()
        {
            _additionCalculator.Calculate("*1,3");
            _calculatorInputValidator.Verify( x => x.IsContainInvalidInput(It.IsAny<Func<bool>>(), It.IsAny<Exception>()), Times.Once);
        }
    }

    public class NewAdditionCalculator : AdditionCalculator
    {
        public NewAdditionCalculator(ICalculatorInputValidator calculatorInputValidator) 
            : base(calculatorInputValidator)
        {
          
        }
        public override char CommaSeperator { get; protected set; } = '-';

        public override string RegexString { get; protected set; } = "[0-9]-(,[0-9]+)+";
    }
}
