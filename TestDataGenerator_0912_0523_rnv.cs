// 代码生成时间: 2025-09-12 05:23:01
using System;

namespace TestDataGeneratorApp
{
    public class TestDataGenerator
    {
        // Generates a random string.
        private static string GenerateRandomString(int length)
        {
            const string valid = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            StringBuilder res = new StringBuilder();
            Random rng = new Random();
            int i;
            for (i = 0; i < length; i++)
            {
                res.Append(valid[rng.Next(valid.Length)]);
            }
            return res.ToString();
        }

        // Generates a random integer within a specified range.
        private static int GenerateRandomInt(int min, int max)
        {
            Random rand = new Random();
            return rand.Next(min, max);
        }

        // Generates a random date within a specified range.
        private static DateTime GenerateRandomDate(DateTime min, DateTime max)
        {
            Random rand = new Random();
            var days = rand.Next((int)(min - max).Days) + (int)(max - min).Days;
            return max.AddDays(-days);
        }

        // Public method to generate test data.
        public static object GenerateTestData()
        {
            try
            {
                string randomString = GenerateRandomString(10); // Generate a string of length 10.
                int randomInt = GenerateRandomInt(1, 100); // Generate an integer between 1 and 100.
                DateTime randomDate = GenerateRandomDate(new DateTime(1990, 1, 1), DateTime.Now); // Generate a date between 1990-01-01 and now.

                return new
                {
                    StringData = randomString,
                    IntData = randomInt,
                    DateData = randomDate
                };
            }
            catch (Exception ex)
            {
                // Log the exception and return null or throw a custom exception
                // depending on how you want to handle the error.
                Console.WriteLine("An error occurred while generating test data: " + ex.Message);
                return null;
            }
        }
    }
}
