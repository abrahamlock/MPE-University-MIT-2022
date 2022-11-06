using Calculator.SOLID.Library.Utils;
using Calculator.SOLID.Library.Validator.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Calculator.SOLID.Library.Calculators
{
    public class DivisionCalculator : BaseCalculator<double>
    {
        private readonly ICalculatorInputValidator _calculatorInputValidator;
        public DivisionCalculator(ICalculatorInputValidator calculatorInputValidator)
                : base(calculatorInputValidator)
        {
            this._calculatorInputValidator = calculatorInputValidator;
        }

        public override string Name => OperationEnum.Divide.ToString();

        public override void CalculatorOperation(IEnumerable<double> values)
        {
            double temp = values.First();

            foreach (var value in values.Skip(1))
            {
                if (!_calculatorInputValidator.IsContainInvalidInput(
                    () => { return value == 0; },
                    new DivideByZeroException("0 is not allow to divide! ")))
                {
                    temp /= value;
                }
            }

            Total = temp;
        }
    }
}
