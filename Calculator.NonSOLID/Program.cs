using Calculator.NonSOLID.Library.Calculators;
using Calculator.NonSOLID.Library.ExtentionMethod;
using Calculator.NonSOLID.Library.Validator;
using System;
using System.Linq;

namespace Calculator.NonSOLID
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("*************************************************** \n");
                Console.WriteLine("****************  Non Solid Programming ************\n");
                Console.WriteLine("Please enter your input numbers to be calculate : \n");
                Console.WriteLine(" { Example : 1,2,3,4 } \n");
                Console.WriteLine("*************************************************** \n");

                var input = Console.ReadLine();

                Console.WriteLine("*************************************************** \n");
                Console.WriteLine("Please Select your Operation as below option: \n");
                Console.WriteLine(" 1 - Sum \n");
                Console.WriteLine(" 2 - Minus \n");
                Console.WriteLine(" 3 - Multiplier \n");
                Console.WriteLine(" 4 - Divide \n");
                Console.WriteLine(" 5 - Show All [Sum, Minus, Multiplier, Divide] \n");
                Console.WriteLine("*************************************************** \n");

                var inputOperation = Console.ReadLine();

                var inputList = input.ToIntList(',');

                if (Convert.ToInt32(inputOperation) == 1)
                {
                    var additionCalculator = new AdditionCalculator();
                    additionCalculator.Calculate(inputList);
                    Console.WriteLine($"Total Sum : " + additionCalculator.Total);
                }
                else if (Convert.ToInt32(inputOperation) == 2)
                {
                    var subtractionCalculator = new SubtractionCalculator();
                    subtractionCalculator.Calculate(inputList);
                    Console.WriteLine($"Total Minus : " + subtractionCalculator.Total);
                }
                else if (Convert.ToInt32(inputOperation) == 3)
                {
                    var multiplicationCalculator = new MultiplicationCalculator();
                    multiplicationCalculator.Calculate(inputList);
                    Console.WriteLine($"Total Multipier : " + multiplicationCalculator.Total);
                }
                else if (Convert.ToInt32(inputOperation) == 4)
                {
                    var divisionCalculator = new DivisionCalculator(new CalculatorInputValidator());
                    divisionCalculator.Calculate(inputList);
                    Console.WriteLine($"Total Division : " + divisionCalculator.Total);
                }
                else
                {
                    var additionCalculator = new AdditionCalculator();
                    additionCalculator.Calculate(inputList);
                    Console.WriteLine($"Total Sum : " + additionCalculator.Total);

                    var subtractionCalculator = new SubtractionCalculator();
                    subtractionCalculator.Calculate(inputList);
                    Console.WriteLine($"Total Minus : " + subtractionCalculator.Total);

                    var multiplicationCalculator = new MultiplicationCalculator();
                    multiplicationCalculator.Calculate(inputList);
                    Console.WriteLine($"Total Multipier : " + multiplicationCalculator.Total);

                    var divisionCalculator = new DivisionCalculator(new CalculatorInputValidator());
                    divisionCalculator.Calculate(inputList);
                    Console.WriteLine($"Total Division : " + divisionCalculator.Total);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Execption : {ex.Message}");
            }

        }
    }
}
