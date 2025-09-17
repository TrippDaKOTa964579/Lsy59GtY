// 代码生成时间: 2025-09-17 20:27:35
 * including error handling, documentation, and maintainability.
 */

using System;

namespace RandomNumberGeneratorApp
{
    /// <summary>
    /// A class responsible for generating random numbers.
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
        /// Generates a random integer within a specified range.
        /// </summary>
        /// <param name="min">The minimum value of the range.</param>
        /// <param name="max">The maximum value of the range.</param>
        /// <returns>A random integer between min and max.</returns>
        public int GenerateRandomNumber(int min, int max)
        {
            if (min > max)
            {
                throw new ArgumentException("Min must be less than or equal to Max", nameof(min));
            }

            return _random.Next(min, max + 1);
        }

        /// <summary>
        /// Generates a random integer within a default range of 0 to Int32.MaxValue.
        /// </summary>
        /// <returns>A random integer between 0 and Int32.MaxValue.</returns>
        public int GenerateRandomNumber()
        {
            return _random.Next();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                RandomNumberGenerator generator = new RandomNumberGenerator();
                int randomNumber = generator.GenerateRandomNumber(1, 100);
                Console.WriteLine($"Random Number: {randomNumber}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}