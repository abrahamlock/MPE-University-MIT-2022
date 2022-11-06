using Calculator.SOLID.Library.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator.SOLID.Library.Calculators.Interface
{
    public interface ICalculator<T> : IOperation
    {
        void Calculate(string input);

        T GetCalulatedValue();
    }
}
