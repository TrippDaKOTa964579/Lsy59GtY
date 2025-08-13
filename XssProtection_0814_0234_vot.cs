// 代码生成时间: 2025-08-14 02:34:05
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace XssProtectionApp
{
    public class XssProtection
    {
        // This method sanitizes the input string to prevent XSS attacks.
        public static string SanitizeInput(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                throw new ArgumentException("Input cannot be null or whitespace.", nameof(input));
            }

            // Remove all HTML tags to prevent XSS attacks.
            input = Regex.Replace(input, "<[^>]*>|&.*?;", "", RegexOptions.Compiled | RegexOptions.IgnoreCase);

            // Optional: Additional sanitization can be added here to cover other cases.
            // For example, removing JavaScript events, encoded characters, etc.

            return input;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string userInput = "<script>alert('XSS')</script>";
                string sanitizedInput = XssProtection.SanitizeInput(userInput);
                Console.WriteLine("User Input: " + userInput);
                Console.WriteLine("Sanitized Input: " + sanitizedInput);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}