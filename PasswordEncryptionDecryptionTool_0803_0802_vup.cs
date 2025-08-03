// 代码生成时间: 2025-08-03 08:02:05
using System;
using System.Security.Cryptography;
using System.Text;

namespace PasswordEncryptionDecryptionTool
{
    /// <summary>
    /// Provides functionality for encrypting and decrypting passwords.
    /// </summary>
    public class PasswordEncryptionDecryptionTool
    {
        private readonly string _key;
        private readonly string _iv;

        /// <summary>
        /// Initializes a new instance of the PasswordEncryptionDecryptionTool class.
        /// </summary>
        /// <param name="key">The encryption key.</param>
        /// <param name="iv">The initialization vector (IV) for encryption.</param>
        public PasswordEncryptionDecryptionTool(string key, string iv)
        {
            _key = key;
            _iv = iv;
        }

        /// <summary>
        /// Encrypts a password using the AES algorithm.
        /// </summary>
        /// <param name="password">The password to encrypt.</param>
        /// <returns>The encrypted password.</returns>
        public string Encrypt(string password)
        {
            if (string.IsNullOrEmpty(password))
            {
                throw new ArgumentException("Password cannot be null or empty.", nameof(password));
            }

            try
            {
                byte[] keyBytes = Encoding.UTF8.GetBytes(_key);
                byte[] ivBytes = Encoding.UTF8.GetBytes(_iv);
                using (Aes aesAlg = Aes.Create())
                {
                    aesAlg.Key = keyBytes;
                    aesAlg.IV = ivBytes;

                    ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);
                    byte[] encryptedBytes = encryptor.TransformFinalBlock(Encoding.UTF8.GetBytes(password), 0, password.Length);

                    return Convert.ToBase64String(encryptedBytes);
                }
            }
            catch (Exception ex)
            {
                throw new CryptographicException("An error occurred during encryption.", ex);
            }
        }

        /// <summary>
        /// Decrypts a password using the AES algorithm.
        /// </summary>
        /// <param name="encryptedPassword">The encrypted password to decrypt.</param>
        /// <returns>The decrypted password.</returns>
        public string Decrypt(string encryptedPassword)
        {
            if (string.IsNullOrEmpty(encryptedPassword))
            {
                throw new ArgumentException("Encrypted password cannot be null or empty.", nameof(encryptedPassword));
            }

            try
            {
                byte[] keyBytes = Encoding.UTF8.GetBytes(_key);
                byte[] ivBytes = Encoding.UTF8.GetBytes(_iv);
                using (Aes aesAlg = Aes.Create())
                {
                    aesAlg.Key = keyBytes;
                    aesAlg.IV = ivBytes;

                    ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);
                    byte[] decryptedBytes = decryptor.TransformFinalBlock(Convert.FromBase64String(encryptedPassword), 0, encryptedPassword.Length);

                    return Encoding.UTF8.GetString(decryptedBytes);
                }
            }
            catch (Exception ex)
            {
                throw new CryptographicException("An error occurred during decryption.", ex);
            }
        }
    }
}
