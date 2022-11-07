using Calculator.SOLID.Factory;
using Calculator.SOLID.Factory.Interface;
using Calculator.SOLID.Manager;
using Calculator.SOLID.Manager.Interface;
using Calculator.SOLID.Library.Calculators;
using Calculator.SOLID.Library.Calculators.Interface;
using Calculator.SOLID.Library.Services;
using Calculator.SOLID.Library.Services.Interface;
using Calculator.SOLID.Library.Validator;
using Calculator.SOLID.Library.Validator.Interface;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Calculator.SOLID
{
    public class Bootstrapper
    {
        private IServiceProvider container;
        protected IServiceCollection services;

        public IServiceScope Scope => container.CreateScope();

        public Bootstrapper()
        {
            services = new ServiceCollection();
            Configure();
            container = services.BuildServiceProvider();
        }

        protected virtual void Configure()
        {
            services.AddScoped<IAllOperationCalculator, AllOperationCalculator>();
            services.AddScoped<IOperationFactory, OperationFactory>();
            services.AddScoped<IConsoleInputOutputService, ConsoleInputOutputService>();
            services.AddScoped<ICalculatorInputValidator, CalculatorInputValidator>();
            services.AddScoped<ICalculatorManager, CalculatorManager>();

            services.AddScoped<ICalculator<int>, AdditionCalculator>();
            services.AddScoped<ICalculator<int>, SubtractionCalculator>();
            services.AddScoped<ICalculator<int>, MultiplicationCalculator>();
            services.AddScoped<ICalculator<double>, DivisionCalculator>();
        }
    }
}
