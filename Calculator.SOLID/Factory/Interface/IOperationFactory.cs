using Calculator.SOLID.Library.Calculators.Interface;
using Calculator.SOLID.Library.Utils;

namespace Calculator.SOLID.Factory.Interface
{
    public interface IOperationFactory
    {
        dynamic GetCalculator(int inputOperation);
    }
}
