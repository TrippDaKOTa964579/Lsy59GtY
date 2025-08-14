// 代码生成时间: 2025-08-14 22:49:04
 * documentation, maintainability, and extensibility.
 */

using System;
using System.Collections.Generic;
using System.Text;

namespace TestDataGeneratorNamespace
{
    public class TestDataGenerator
    {
        // Generates a random string of a specified length.
        public string GenerateRandomString(int length)
        {
            if (length <= 0)
            {
                throw new ArgumentException("Length must be greater than zero.");
            }

            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var random = new Random();
            var result = new StringBuilder(length);
            for (var i = 0; i < length; i++)
            {
                result.Append(chars[random.Next(chars.Length)]);
            }
            return result.ToString();
        }

        // Generates a random integer within a specified range.
        public int GenerateRandomInteger(int min, int max)
        {
            if (min > max)
            {
                throw new ArgumentException("Min value must be less than or equal to max value.");
            }

            var random = new Random();
            return random.Next(min, max + 1);
        }

        // Generates a random date within a specified range.
        public DateTime GenerateRandomDate(DateTime minDate, DateTime maxDate)
        {
            if (minDate > maxDate)
            {
                throw new ArgumentException("Min date must be less than or equal to max date.");
            }

            var random = new Random();
            var ticksMin = minDate.Ticks;
            var ticksMax = maxDate.Ticks;
            var ticks = ticksMin + (long)((random.NextDouble() * (ticksMax - ticksMin)));
            return new DateTime(ticks);
        }

        // Generates a random list of strings with a specified range of length.
        public List<string> GenerateRandomStringList(int minCount, int maxCount, int stringLength)
        {
            if (minCount < 0 || maxCount < 0 || minCount > maxCount)
            {
                throw new ArgumentException("Invalid minCount or maxCount.");
            }

            var randomCount = GenerateRandomInteger(minCount, maxCount);
            var list = new List<string>();
            for (var i = 0; i < randomCount; i++)
            {
                list.Add(GenerateRandomString(stringLength));
            }
            return list;
        }
    }
}
