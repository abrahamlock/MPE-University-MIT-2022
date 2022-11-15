using Calculator.SOLID.Manager.Interface;
using Microsoft.Extensions.DependencyInjection;

namespace Calculator.SOLID
{
    class Program
    {
        static void Main(string[] args)
        {
            var bootstrapper = new Bootstrapper();
            using (IServiceScope scope = bootstrapper.Scope)
            {
                var service = scope.ServiceProvider.GetService<ICalculatorManager>();
                while(true)
                service.StartCalculation();
            }
        }
    }
}
