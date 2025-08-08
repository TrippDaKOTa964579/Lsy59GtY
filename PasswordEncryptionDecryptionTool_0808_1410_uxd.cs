// 代码生成时间: 2025-08-08 14:10:14
using System;
using System.Security.Cryptography;
using System.Text;

namespace PasswordEncryptionDecryptionTool
{
    // 提供密码加密和解密的工具类
    public class PasswordEncryptionDecryptionTool
    {
        private readonly byte[] _key;
        private readonly byte[] _iv;

        public PasswordEncryptionDecryptionTool(byte[] key, byte[] iv)
        {
            if (key == null || key.Length != 32)
                throw new ArgumentException("Key must be 32 bytes long.");
            if (iv == null || iv.Length != 16)
                throw new ArgumentException("IV must be 16 bytes long.");

            _key = key;
            _iv = iv;
        }

        // 加密密码
        public string EncryptPassword(string password)
        {
            if (string.IsNullOrEmpty(password))
                throw new ArgumentException("Password cannot be null or empty.");

            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = _key;
                aesAlg.IV = _iv;

                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                byte[] encrypted;
                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            swEncrypt.Write(password);
                        }
                        encrypted = msEncrypt.ToArray();
                    }
                }

                return Convert.ToBase64String(encrypted);
            }
        }

        // 解密密码
        public string DecryptPassword(string encryptedData)
        {
            if (string.IsNullOrEmpty(encryptedData))
                throw new ArgumentException("Encrypted data cannot be null or empty.");

            byte[] encryptedBytes = Convert.FromBase64String(encryptedData);

            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = _key;
                aesAlg.IV = _iv;

                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                byte[] decrypted;
                using (MemoryStream msDecrypt = new MemoryStream(encryptedBytes))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {
                            decrypted = Encoding.UTF8.GetBytes(srDecrypt.ReadToEnd());
                        }
                    }
                }

                return Encoding.UTF8.GetString(decrypted);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // 生成密钥和IV（在实际应用中应该使用安全的方法生成）
                byte[] key = Encoding.UTF8.GetBytes("32byteslongkeyforaes256");
                byte[] iv = Encoding.UTF8.GetBytes("16byteslongivforaes");

                PasswordEncryptionDecryptionTool tool = new PasswordEncryptionDecryptionTool(key, iv);

                string password = "SecurePassword123!";
                string encryptedPassword = tool.EncryptPassword(password);
                string decryptedPassword = tool.DecryptPassword(encryptedPassword);

                Console.WriteLine($"Original Password: {password}
Encrypted Password: {encryptedPassword}
Decrypted Password: {decryptedPassword}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}
