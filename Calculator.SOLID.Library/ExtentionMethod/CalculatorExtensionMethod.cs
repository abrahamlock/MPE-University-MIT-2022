using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Calculator.SOLID.Library.ExentionMethod
{
    public static class CalculatorExtensionMethod
    {
        public static IEnumerable<T> ToTypeList<T>(this string input, char commaSeperator) 
            => input.Split(commaSeperator).Select(x => Convert.ChangeType(x, typeof(T))).Cast<T>();
    }
}
