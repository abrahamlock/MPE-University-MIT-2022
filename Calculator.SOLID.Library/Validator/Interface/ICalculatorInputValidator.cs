using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator.SOLID.Library.Validator.Interface
{
    public interface ICalculatorInputValidator
    {
        bool IsContainInvalidInput(Func<bool> func, Exception exception);
    }
}
