using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator.SOLID.Library.Services.Interface
{
    public interface IConsoleInputOutputService
    {
        void WriteLine(string text);

        string ReadLine();
    }
}
