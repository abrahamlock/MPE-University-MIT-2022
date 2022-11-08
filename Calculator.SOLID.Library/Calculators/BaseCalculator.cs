using Calculator.SOLID.Library.Calculators.Interface;
using Calculator.SOLID.Library.ExentionMethod;
using Calculator.SOLID.Library.Validator.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Calculator.SOLID.Library.Calculators
{
    public abstract class BaseCalculator<T> : ICalculator<T>, ICalculatorProp
    {
        protected T Total;
        private readonly ICalculatorInputValidator _calculatorInputValidator;

        public BaseCalculator(ICalculatorInputValidator calculatorInputValidator)
        {
            this._calculatorInputValidator = calculatorInputValidator;
        }

        #region ICalculatorProp
        public virtual char CommaSeperator { get; protected set; } = ',';
        public virtual string RegexString { get; protected set; } = "[0-9]+(,[0-9]+)+";
        #endregion

        public abstract string Name { get; }

        public abstract void CalculatorOperation(IEnumerable<T> values);

        public void Calculate(string input)
        {

            if (this._calculatorInputValidator.IsContainInvalidInput(
                 () =>
                 {
                     var r = new Regex(RegexString);
                     return (!r.IsMatch(input));
                 }, new FormatException($" {input} was not in correct format! ")
             ))
                return;

            IEnumerable<T> values = input.ToTypeList<T>(CommaSeperator);
            this.CalculatorOperation(values);
        }

        public T GetCalulatedValue() => Total ?? default;
    }
}
