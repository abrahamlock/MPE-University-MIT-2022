using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator.SOLID.Library.Calculators.Interface
{
    public interface ICalculatorProp
    {
        char CommaSeperator { get; }
        string RegexString { get; }
    }
}
