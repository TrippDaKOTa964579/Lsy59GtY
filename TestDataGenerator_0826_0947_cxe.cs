// 代码生成时间: 2025-08-26 09:47:42
using System;
using System.Collections.Generic;
using System.Text;

namespace TestDataGeneratorApp
{
    /// <summary>
    /// A class responsible for generating test data.
    /// </summary>
    public class TestDataGenerator
    {
        /// <summary>
        /// Generates a random string.
        /// </summary>
        /// <param name="length">The length of the string to generate.</param>
        /// <returns>Returns a random string of specified length.</returns>
        private static string GenerateRandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var random = new Random();
            var result = new char[length];
            for (int i = 0; i < length; i++)
            {
                result[i] = chars[random.Next(chars.Length)];
            }
            return new string(result);
        }

        /// <summary>
        /// Generates a list of random strings.
        /// </summary>
        /// <param name="count">The number of strings to generate.</param>
        /// <param name="length">The length of each string.</param>
        /// <returns>Returns a list of random strings.</returns>
        public static List<string> GenerateRandomStringList(int count, int length)
        {
            List<string> resultList = new List<string>();
            for (int i = 0; i < count; i++)
            {
                try
                {
                    resultList.Add(GenerateRandomString(length));
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error generating random string: {ex.Message}");
                }
            }
            return resultList;
        }

        /// <summary>
        /// The main entry point for the program.
        /// </summary>
        /// <param name="args">Command line arguments (not used in this example).</param>
        public static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Enter the number of test strings to generate: ");
                int numberOfStrings = int.Parse(Console.ReadLine());

                Console.WriteLine("Enter the length of each test string: ");
                int stringLength = int.Parse(Console.ReadLine());

                var testStrings = GenerateRandomStringList(numberOfStrings, stringLength);

                foreach (var str in testStrings)
                {
                    Console.WriteLine(str);
                }
            }
            catch (FormatException ex)
            {
                Console.WriteLine($"Invalid input format: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
            }
        }
    }
}