// 代码生成时间: 2025-09-20 15:44:15
using System;
using System.Collections.Generic;

// 定义一个简单的用户类，包含用户名和访问权限
public class User
{
    public string Username { get; set; }
    public string[] Permissions { get; set; }
}

// 定义访问控制管理器类
public class AccessControlManager
{
    private readonly List<User> users;

    // 构造函数，初始化用户列表
    public AccessControlManager()
    {
        users = new List<User>
        {
            new User { Username = "admin", Permissions = new[] { "view", "edit", "delete" } },
            new User { Username = "user", Permissions = new[] { "view" } }
        };
    }

    // 检查用户是否具有指定的权限
    public bool HasPermission(string username, string permission)
    {
        // 尝试找到用户
        var user = users.Find(u => u.Username == username);
        if (user == null)
        {
            Console.WriteLine("Error: User not found.");
            return false;
        }

        // 检查用户是否具有指定权限
        return user.Permissions != null && user.Permissions.Contains(permission);
    }
}

// 程序入口点
class Program
{
    static void Main(string[] args)
    {
        try
        {
            // 创建访问控制管理器实例
            var accessControlManager = new AccessControlManager();

            // 测试访问权限
            var username = "admin";
            var permission = "edit";
            if (accessControlManager.HasPermission(username, permission))
            {
                Console.WriteLine($"User {username} has {permission} permission.");
            }
            else
            {
                Console.WriteLine($"User {username} does not have {permission} permission.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}