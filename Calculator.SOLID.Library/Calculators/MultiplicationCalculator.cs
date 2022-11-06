using Calculator.SOLID.Library.Utils;
using Calculator.SOLID.Library.Validator.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Calculator.SOLID.Library.Calculators
{
    public class MultiplicationCalculator : BaseCalculator<int>
    {
        public MultiplicationCalculator(ICalculatorInputValidator calculatorInputValidator)
               : base(calculatorInputValidator)
        {

        }


        public override string Name => OperationEnum.Multipier.ToString();

        public override void CalculatorOperation(IEnumerable<int> values)
        {
            int temp = values.First();

            foreach (var value in values.Skip(1))
            {
                temp *= value;
            }

            Total = temp;
        }
    }
}
