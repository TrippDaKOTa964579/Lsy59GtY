// 代码生成时间: 2025-08-03 20:15:32
using System;
using System.Security.Cryptography;
using System.Text;

namespace HashCalculatorApp
{
    /// <summary>
    /// HashValue计算工具类，用于计算给定字符串的哈希值。
    /// </summary>
    public class HashCalculator
    {
        /// <summary>
        /// 计算字符串的MD5哈希值。
        /// </summary>
        /// <param name="input">待计算哈希的字符串。</param>
        /// <returns>MD5哈希字符串。</returns>
        public string CalculateMd5Hash(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                throw new ArgumentException("输入字符串不能为空。", nameof(input));
            }

            using (var md5 = MD5.Create())
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);
                return BitConverter.ToString(hashBytes).Replace("-", string.Empty).ToLowerInvariant();
            }
        }

        /// <summary>
        /// 计算字符串的SHA256哈希值。
        /// </summary>
        /// <param name="input">待计算哈希的字符串。</param>
        /// <returns>SHA256哈希字符串。</returns>
        public string CalculateSha256Hash(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                throw new ArgumentException("输入字符串不能为空。", nameof(input));
            }

            using (var sha256 = SHA256.Create())
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(input);
                byte[] hashBytes = sha256.ComputeHash(inputBytes);
                return BitConverter.ToString(hashBytes).Replace("-", string.Empty).ToLowerInvariant();
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var calculator = new HashCalculator();

                string input = "Hello, World!";
                string md5Hash = calculator.CalculateMd5Hash(input);
                string sha256Hash = calculator.CalculateSha256Hash(input);

                Console.WriteLine($"MD5 Hash: {md5Hash}");
                Console.WriteLine($"SHA256 Hash: {sha256Hash}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"发生错误: {ex.Message}");
            }
        }
    }
}