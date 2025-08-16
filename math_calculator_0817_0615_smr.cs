// 代码生成时间: 2025-08-17 06:15:03
 * and follows C# best practices for maintainability and extensibility.
 */

using System;

namespace MathCalculatorApp
{
    public class MathCalculator
    {
        // Adds two numbers
        public double Add(double a, double b)
        {
            return a + b;
        }

        // Subtracts two numbers
        public double Subtract(double a, double b)
        {
            return a - b;
        }

        // Multiplies two numbers
        public double Multiply(double a, double b)
        {
            return a * b;
        }

        // Divides two numbers
        public double Divide(double a, double b)
        {
            if (b == 0)
            {
                throw new DivideByZeroException("Cannot divide by zero.");
            }
            return a / b;
        }

        // Computes the power of a number
        public double Power(double baseNumber, double exponent)
        {
            return Math.Pow(baseNumber, exponent);
        }

        // Computes the square root of a number
        public double SquareRoot(double number)
        {
            if (number < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(number), "Number cannot be negative for square root operation.");
            }
            return Math.Sqrt(number);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            MathCalculator calculator = new MathCalculator();

            try
            {
                double sum = calculator.Add(10, 5);
                Console.WriteLine($"Addition: 10 + 5 = {sum}");

                double difference = calculator.Subtract(10, 5);
                Console.WriteLine($"Subtraction: 10 - 5 = {difference}");

                double product = calculator.Multiply(10, 5);
                Console.WriteLine($"Multiplication: 10 * 5 = {product}");

                double quotient = calculator.Divide(10, 5);
                Console.WriteLine($"Division: 10 / 5 = {quotient}");

                double powerResult = calculator.Power(2, 3);
                Console.WriteLine($"Power: 2^3 = {powerResult}");

                double squareRoot = calculator.SquareRoot(16);
                Console.WriteLine($"Square Root: {16} = {squareRoot}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}