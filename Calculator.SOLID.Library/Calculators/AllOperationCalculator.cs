using Calculator.SOLID.Library.Calculators.Interface;
using Calculator.SOLID.Library.Services.Interface;
using System.Collections.Generic;

namespace Calculator.SOLID.Library.Calculators
{
    public class AllOperationCalculator : IAllOperationCalculator
    {
        private readonly IEnumerable<ICalculator<int>> _calculators;
        private readonly ICalculator<double> _divCalculators;
        private readonly IConsoleInputOutputService _consoleInputOutput;

        public AllOperationCalculator(IEnumerable<ICalculator<int>> calculators, ICalculator<double> divCalculators, 
            IConsoleInputOutputService consoleInputOutput)
        {
            this._calculators = calculators;
            this._divCalculators = divCalculators;
            this._consoleInputOutput = consoleInputOutput;
        }

        public void CalculateAll(string input)
        {
            foreach (var calculator in _calculators)
            {
                calculator.Calculate(input);
                _consoleInputOutput.WriteLine($"Total {calculator.Name} : " + calculator.GetCalulatedValue());
            }

            this._divCalculators.Calculate(input);
            _consoleInputOutput.WriteLine($"Total {_divCalculators.Name} : " + _divCalculators.GetCalulatedValue());

        }
    }
}
