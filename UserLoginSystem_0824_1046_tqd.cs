// 代码生成时间: 2025-08-24 10:46:43
// UserLoginSystem.cs
// 这个类实现了一个简单的用户登录验证系统

using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace UserLoginSystem
{
    // 用户类，包含用户名和密码
    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    // 登录服务类，负责验证用户登录
    public class LoginService
    {
        private readonly Dictionary<string, string> _userCredentials;

        // 构造函数，初始化用户凭据字典
        public LoginService()
        {
            _userCredentials = new Dictionary<string, string>
            {
                { "user1", "password123" }, // 示例用户1
                { "user2", "password456" }  // 示例用户2
            };
        }

        // 异步登录方法
        public async Task<bool> LoginAsync(string username, string password)
        {
            try
            {
                // 检查用户名是否存在
                if (_userCredentials.ContainsKey(username))
                {
                    // 验证密码是否匹配
                    string storedPassword = _userCredentials[username];
                    string hashedPassword = GenerateHash(password);

                    if (string.Equals(hashedPassword, storedPassword, StringComparison.Ordinal))
                    {
                        return true;
                    }
                }
                else
                {
                    Console.WriteLine("Username not found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

            return false;
        }

        // 生成密码的哈希值
        private string GenerateHash(string input)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] sourceBytes = Encoding.UTF8.GetBytes(input);
                byte[] hashBytes = sha256Hash.ComputeHash(sourceBytes);
                StringBuilder sb = new StringBuilder();

                foreach (byte b in hashBytes)
                {
                    sb.Append(b.ToString("x2"));
                }

                return sb.ToString();
            }
        }
    }

    class Program
    {
        static async Task Main(string[] args)
        {
            LoginService loginService = new LoginService();

            Console.WriteLine("Enter username: ");
            string username = Console.ReadLine();
            Console.WriteLine("Enter password: ");
            string password = Console.ReadLine();

            bool isLoggedIn = await loginService.LoginAsync(username, password);

            if (isLoggedIn)
            {
                Console.WriteLine("You are logged in.");
            }
            else
            {
                Console.WriteLine("You are not logged in.");
            }
        }
    }
}
