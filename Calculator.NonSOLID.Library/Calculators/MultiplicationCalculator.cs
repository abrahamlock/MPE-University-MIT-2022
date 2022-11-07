using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Calculator.NonSOLID.Library.Calculators
{
    public class MultiplicationCalculator
    {
        public int Total = 0;

        public void Calculate(IEnumerable<int> values)
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
