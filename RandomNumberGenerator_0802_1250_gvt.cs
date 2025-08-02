// 代码生成时间: 2025-08-02 12:50:59
using System;

namespace RandomNumberGeneratorApp
{
    /// <summary>
    /// A class to generate random numbers within a specified range.
    /// </summary>
    public class RandomNumberGenerator
    {
        private readonly Random _random;

        /// <summary>
        /// Initializes a new instance of the RandomNumberGenerator class.
        /// </summary>
        public RandomNumberGenerator()
        {
            _random = new Random();
        }

        /// <summary>
        /// Generates a random number within a specified range.
        /// </summary>
        /// <param name="min">The minimum value of the range.</param>
        /// <param name="max">The maximum value of the range.</param>
        /// <returns>A random integer within the specified range.</returns>
        public int GenerateRandomNumber(int min, int max)
        {
            if (min >= max)
            {
                throw new ArgumentException("The min value must be less than the max value.");
            }

            return _random.Next(min, max + 1);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var rng = new RandomNumberGenerator();
                int min = 1;
                int max = 100;
                int randomNumber = rng.GenerateRandomNumber(min, max);
                Console.WriteLine($"Random number between {min} and {max}: {randomNumber}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}