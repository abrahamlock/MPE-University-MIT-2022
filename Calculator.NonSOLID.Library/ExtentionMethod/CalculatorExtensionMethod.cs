using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Calculator.NonSOLID.Library.ExtentionMethod
{
    public static class CalculatorExtensionMethod
    {
        public static IEnumerable<int> ToIntList(this string input, char commaSeperator)
        {
            return input.Split(commaSeperator).Select(int.Parse);
        }
    }
}
