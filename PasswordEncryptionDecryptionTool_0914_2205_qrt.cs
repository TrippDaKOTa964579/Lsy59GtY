// 代码生成时间: 2025-09-14 22:05:34
using System;
using System.Security.Cryptography;
using System.Text;

namespace PasswordEncryptionDecryptionTool
{
    public class PasswordEncryptionDecryptionTool
    {
        // 定义加密算法
        private static readonly string EncryptionAlgorithm = "AES";
        private static readonly int KeySize = 256;
        private static readonly int KeyBytes = 32;
        private static readonly int IVBytes = 16;

        // 加密密码
        public static string Encrypt(string plainText, byte[] key, byte[] iv)
        {
            if (string.IsNullOrEmpty(plainText))
            {
                throw new ArgumentNullException(nameof(plainText), "Plain text cannot be null or empty.");
            }
            if (key == null || key.Length != KeyBytes)
            {
                throw new ArgumentException("Key must be 32 bytes long.", nameof(key));
            }
            if (iv == null || iv.Length != IVBytes)
            {
                throw new ArgumentException("IV must be 16 bytes long.", nameof(iv));
            }

            using (var aesAlg = Aes.Create())
            {
                aesAlg.Key = key;
                aesAlg.IV = iv;

                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);
                using (var msEncrypt = new MemoryStream())
                {
                    using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (var swEncrypt = new StreamWriter(csEncrypt))
                        {
                            swEncrypt.Write(plainText);
                        }
                    }
                    return Convert.ToBase64String(msEncrypt.ToArray());
                }
            }
        }

        // 解密密码
        public static string Decrypt(string cipherText, byte[] key, byte[] iv)
        {
            if (string.IsNullOrEmpty(cipherText))
            {
                throw new ArgumentNullException(nameof(cipherText), "Cipher text cannot be null or empty.");
            }
            if (key == null || key.Length != KeyBytes)
            {
                throw new ArgumentException("Key must be 32 bytes long.", nameof(key));
            }
            if (iv == null || iv.Length != IVBytes)
            {
                throw new ArgumentException("IV must be 16 bytes long.", nameof(iv));
            }

            using (var aesAlg = Aes.Create())
            {
                aesAlg.Key = key;
                aesAlg.IV = iv;

                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);
                using (var msDecrypt = new MemoryStream(Convert.FromBase64String(cipherText)))
                {
                    using (var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (var srDecrypt = new StreamReader(csDecrypt))
                        {
                            string decrypted = srDecrypt.ReadToEnd();
                            return decrypted;
                        }
                    }
                }
            }
        }
    }
}
