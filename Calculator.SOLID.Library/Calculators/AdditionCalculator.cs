using Calculator.SOLID.Library.Validator.Interface;
using Calculator.SOLID.Library.Utils;
using System.Collections.Generic;
using System.Linq;

namespace Calculator.SOLID.Library.Calculators
{
    public class AdditionCalculator : BaseCalculator<int>
    {
        public AdditionCalculator(ICalculatorInputValidator calculatorInputValidator)
            : base(calculatorInputValidator)
        {
           
        }

        public override string Name => OperationEnum.Sum.ToString();

        public override void CalculatorOperation(IEnumerable<int> values)
        {
            Total = values.Sum();
        }
    }
}
