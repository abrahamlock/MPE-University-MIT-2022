using Calculator.SOLID.Library.Services.Interface;
using Calculator.SOLID.Library.Validator.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Calculator.SOLID.Library.Validator
{
    public class CalculatorInputValidator : ICalculatorInputValidator
    {
        public bool IsContainInvalidInput(Func<bool> func, Exception exception)
        {
            if (func())
            {
                throw exception;
            }

            return false;
        }
    }
}
