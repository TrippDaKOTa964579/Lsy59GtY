// 代码生成时间: 2025-09-23 18:52:54
using System;
using System.Security.Cryptography;
using System.Text;

namespace PasswordTool
{
    public class PasswordEncryptionDecryption
    {
        // Encrypts a password using AES encryption
        public string EncryptPassword(string password)
        {
            if (string.IsNullOrEmpty(password))
            {
                throw new ArgumentException("Password cannot be null or empty.");
            }

            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.GenerateKey();
                aesAlg.GenerateIV();

                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                byte[] encrypted = PerformCryptoTransform(Encoding.UTF8.GetBytes(password), encryptor);

                return Convert.ToBase64String(encrypted);
            }
        }

        // Decrypts a password that was previously encrypted with EncryptPassword
        public string DecryptPassword(string encryptedPassword)
        {
            if (string.IsNullOrEmpty(encryptedPassword))
            {
                throw new ArgumentException("Encrypted password cannot be null or empty.");
            }

            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Convert.FromBase64String(encryptedPassword);
                aesAlg.IV = Convert.FromBase64String(encryptedPassword.Substring(0, 16));

                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                byte[] decrypted = PerformCryptoTransform(Convert.FromBase64String(encryptedPassword.Substring(16)), decryptor);

                return Encoding.UTF8.GetString(decrypted);
            }
        }

        private byte[] PerformCryptoTransform(byte[] data, ICryptoTransform transform)
        {
            using (var ms = new MemoryStream())
            {
                using (var cs = new CryptoStream(ms, transform, CryptoStreamMode.Write))
                {
                    cs.Write(data, 0, data.Length);
                    cs.FlushFinalBlock();
                }
                return ms.ToArray();
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                PasswordEncryptionDecryption tool = new PasswordEncryptionDecryption();

                string originalPassword = "MySecurePassword123";
                string encryptedPassword = tool.EncryptPassword(originalPassword);
                Console.WriteLine($"Encrypted Password: {encryptedPassword}");

                string decryptedPassword = tool.DecryptPassword(encryptedPassword);
                Console.WriteLine($"Decrypted Password: {decryptedPassword}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}