using Calculator.NonSOLID.Library.Validator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Calculator.NonSOLID.Library.Calculators
{
    public class DivisionCalculator
    {
        public double Total = 0;
        private CalculatorInputValidator _validator;

        public DivisionCalculator(CalculatorInputValidator validator)
        {
            _validator = validator;
        }

        public void Calculate(IEnumerable<int> values)
        {
            double temp = values.First();

            foreach (var value in values.Skip(1))
            {
                _validator.IsContainZeroAsInput(value);             
                temp /= value;

            }

            Total = temp;
        }
    }
}
