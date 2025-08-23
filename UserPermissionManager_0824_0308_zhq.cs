// 代码生成时间: 2025-08-24 03:08:13
using System;
using System.Collections.Generic;
using System.Linq;

// 用户权限管理系统
namespace UserPermissionSystem
{
    // 用户类，包含用户权限信息
    public class User
# 增强安全性
    {
        public string UserId { get; set; }
        public string Username { get; set; }
        public List<string> Permissions { get; set; } = new List<string>();
    }

    // 权限管理器类
    public class PermissionManager
    {
        private List<User> users;
# 增强安全性

        // 构造函数，初始化用户列表
        public PermissionManager()
        {
            users = new List<User>();
        }
# FIXME: 处理边界情况

        // 添加用户
        public void AddUser(string userId, string username)
        {
            var user = users.FirstOrDefault(u => u.UserId == userId);
# 添加错误处理
            if (user != null)
            {
                throw new InvalidOperationException($"User with ID {userId} already exists.");
            }

            users.Add(new User { UserId = userId, Username = username });
        }

        // 删除用户
        public void RemoveUser(string userId)
        {
# NOTE: 重要实现细节
            var user = users.FirstOrDefault(u => u.UserId == userId);
            if (user == null)
            {
                throw new InvalidOperationException($"User with ID {userId} not found.");
# FIXME: 处理边界情况
            }

            users.Remove(user);
# 增强安全性
        }
# TODO: 优化性能

        // 添加权限
        public void AddPermission(string userId, string permission)
        {
            var user = users.FirstOrDefault(u => u.UserId == userId);
            if (user == null)
            {
                throw new InvalidOperationException($"User with ID {userId} not found.");
            }

            if (!user.Permissions.Contains(permission))
            {
                user.Permissions.Add(permission);
            }
        }

        // 移除权限
# NOTE: 重要实现细节
        public void RemovePermission(string userId, string permission)
# FIXME: 处理边界情况
        {
# 优化算法效率
            var user = users.FirstOrDefault(u => u.UserId == userId);
# 增强安全性
            if (user == null)
            {
                throw new InvalidOperationException($"User with ID {userId} not found.");
            }

            if (user.Permissions.Contains(permission))
            {
                user.Permissions.Remove(permission);
# TODO: 优化性能
            }
        }

        // 检查用户是否有特定权限
        public bool HasPermission(string userId, string permission)
        {
# 优化算法效率
            var user = users.FirstOrDefault(u => u.UserId == userId);
            if (user == null)
# TODO: 优化性能
            {
                throw new InvalidOperationException($"User with ID {userId} not found.");
            }

            return user.Permissions.Contains(permission);
        }

        // 列出指定用户的权限
        public List<string> ListPermissions(string userId)
        {
            var user = users.FirstOrDefault(u => u.UserId == userId);
# 添加错误处理
            if (user == null)
            {
                throw new InvalidOperationException($"User with ID {userId} not found.");
            }
# 扩展功能模块

            return user.Permissions;
        }
# 扩展功能模块
    }

    // 程序主入口点
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var permissionManager = new PermissionManager();

                // 添加用户
                permissionManager.AddUser("1", "Alice");
                permissionManager.AddUser("2", "Bob");

                // 添加权限
                permissionManager.AddPermission("1", "Read");
                permissionManager.AddPermission("1", "Write");
                permissionManager.AddPermission("2", "Read");

                // 检查权限
                Console.WriteLine($"Alice has Read permission: {permissionManager.HasPermission("1", "Read")}");

                // 列出权限
                Console.WriteLine($"Permissions for Alice: {string.Join(", ", permissionManager.ListPermissions("1"))}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
# FIXME: 处理边界情况
