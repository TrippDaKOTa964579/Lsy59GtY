// 代码生成时间: 2025-09-02 14:23:04
using System;
using System.Security.Cryptography;
using System.Text;

namespace HashCalculator
{
    /// <summary>
    /// A utility class for calculating hash values.
    /// </summary>
    public class HashCalculator
    {
        /// <summary>
        /// Calculates the SHA256 hash of the input string.
        /// </summary>
        /// <param name="input">The string to be hashed.</param>
        /// <returns>The SHA256 hash of the input string.</returns>
        /// <exception cref="ArgumentNullException">Thrown when the input string is null.</exception>
        public static string CalculateSHA256Hash(string input)
        {
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input), "Input string cannot be null.");
            }

            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(input);
                byte[] hash = sha256.ComputeHash(bytes);
                StringBuilder builder = new StringBuilder(2 * hash.Length);
                for (int i = 0; i < hash.Length; i++)
                {
                    builder.Append(hash[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        /// <summary>
        /// Main method for demonstrating the hash calculator.
        /// </summary>
        /// <param name="args">Command line arguments.</param>
        public static void Main(string[] args)
        {
            try
            {
                string input = "Hello, World!"; // Example input
                string hash = CalculateSHA256Hash(input);
                Console.WriteLine($"The SHA256 hash of '{input}' is: {hash}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}