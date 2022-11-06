using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Calculator.NonSOLID.Library.Calculators
{
    public class AdditionCalculator
    {
        public int Total = 0;

        public void Calculate(IEnumerable<int> values)
        {
            Total = values.Sum();
        }
    }
}
