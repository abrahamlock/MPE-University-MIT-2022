using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator.NonSOLID.Library.Validator
{
    public class CalculatorInputValidator
    {
        public void IsContainZeroAsInput(int input)
        {
            if (input == 0)
                throw new DivideByZeroException("0 is not allow to divide! ");
        }
    }
}
