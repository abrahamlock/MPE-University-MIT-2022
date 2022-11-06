using Calculator.SOLID.Library.Services.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator.SOLID.Library.Services
{
    public class ConsoleInputOutputService : IConsoleInputOutputService
    {
        public void Write(string text, params object[] args)
        {
            Console.Write(text, args);
        }

        public void WriteLine(string text)
        {
            Console.WriteLine(text);
        }

        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
