using Calculator.SOLID.Factory.Interface;
using Calculator.SOLID.Library.Calculators.Interface;
using Calculator.SOLID.Library.Utils;
using System.Collections.Generic;
using System.Linq;

namespace Calculator.SOLID.Factory
{
    internal class OperationFactory : IOperationFactory
    {
        private readonly IEnumerable<ICalculator<int>> _calculators;
        private readonly ICalculator<double> _divCalculators;

        public OperationFactory(IEnumerable<ICalculator<int>> calculators, ICalculator<double> divCalculators)
        {
            this._calculators = calculators;
            _divCalculators = divCalculators;
        }

        public dynamic GetCalculator(int inputOperation)
        {
            var operationEnum = (OperationEnum)inputOperation;

            return operationEnum switch
            {
                OperationEnum.Sum => GetCalculatorInstance(operationEnum),
                OperationEnum.Minus => GetCalculatorInstance(operationEnum),
                OperationEnum.Multipier => GetCalculatorInstance(operationEnum),
                OperationEnum.Divide => _divCalculators,
                _ => default,
            };
        }

        private ICalculator<int> GetCalculatorInstance(OperationEnum operationEnum)
            => _calculators.Where(x => x.Name == operationEnum.ToString())?.First();

    }
}
