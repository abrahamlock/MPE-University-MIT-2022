using Calculator.SOLID.Manager.Interface;
using Calculator.SOLID.Library.Services.Interface;
using System;
using Calculator.SOLID.Factory.Interface;
using Calculator.SOLID.Library.Calculators.Interface;

namespace Calculator.SOLID.Manager
{
    public class CalculatorManager : ICalculatorManager
    {
        private readonly IOperationFactory _operationFactory;
        private readonly IConsoleInputOutputService _consoleInputOutput;
        private readonly IAllOperationCalculator _allOperationCalculator;

        public CalculatorManager(IOperationFactory operationFactory, IConsoleInputOutputService consoleInputOutput
            , IAllOperationCalculator _allOperationCalculator)
        {
            this._operationFactory = operationFactory;
            this._consoleInputOutput = consoleInputOutput;
            this._allOperationCalculator = _allOperationCalculator;
        }

        public void StartCalculation()
        {
            try
            {
                _consoleInputOutput.WriteLine("*************************************************** \n");
                _consoleInputOutput.WriteLine("*****************  Solid Programming  ************\n");
                _consoleInputOutput.WriteLine("Please enter your input numbers to be calculate : \n");
                _consoleInputOutput.WriteLine(" { Example : 1,2,3,4 } \n");
                _consoleInputOutput.WriteLine("*************************************************** \n");

                var input = Console.ReadLine();

                _consoleInputOutput.WriteLine("*************************************************** \n");
                _consoleInputOutput.WriteLine("Please Select your Operation as below option: \n");
                _consoleInputOutput.WriteLine(" 1 - Sum \n");
                _consoleInputOutput.WriteLine(" 2 - Minus \n");
                _consoleInputOutput.WriteLine(" 3 - Multiplier \n");
                _consoleInputOutput.WriteLine(" 4 - Divide \n");
                _consoleInputOutput.WriteLine(" 5 - Show All [Sum, Minus, Multiplier, Divide] \n");
                _consoleInputOutput.WriteLine("*************************************************** \n");

                var inputOperation = Console.ReadLine();
                var calculator = _operationFactory.GetCalculator(Convert.ToInt32(inputOperation));

                if (calculator is ICalculator<int> || calculator is ICalculator<double>)
                {
                    calculator.Calculate(input);
                    _consoleInputOutput.WriteLine($"Total {calculator.Name} : " + calculator.GetCalulatedValue());
                }
                else
                {
                    _allOperationCalculator.CalculateAll(input);
                }
            }
            catch (Exception ex)
            {
                _consoleInputOutput.WriteLine($"Exception : {ex.Message} ");
            }

        }
    }
}
