using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Calculator.NonSOLID.Library.Tests
{
    public static class CalculatorTestHelper
    {
        public static IEnumerable<int> ToIntergerList(this string input)
        {
            return input.Split(',').Select(int.Parse);
        }
    }
}
