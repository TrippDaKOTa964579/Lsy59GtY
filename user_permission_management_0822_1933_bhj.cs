// 代码生成时间: 2025-08-22 19:33:13
using System;
# NOTE: 重要实现细节
using System.Collections.Generic;
using System.Linq;

// 权限管理类
public class PermissionManager
{
    private Dictionary<string, List<string>> userPermissions;

    public PermissionManager()
    {
# FIXME: 处理边界情况
        userPermissions = new Dictionary<string, List<string>>();
    }

    // 添加用户权限
    public void AddUserPermission(string userId, string permission)
    {
        if (!userPermissions.ContainsKey(userId))
# FIXME: 处理边界情况
        {
            userPermissions[userId] = new List<string>();
        }

        if (!userPermissions[userId].Contains(permission))
        {
            userPermissions[userId].Add(permission);
        }
    }
# 改进用户体验

    // 移除用户权限
# 添加错误处理
    public bool RemoveUserPermission(string userId, string permission)
    {
        if (!userPermissions.ContainsKey(userId))
        {
            return false;
        }

        return userPermissions[userId].Remove(permission);
    }
# FIXME: 处理边界情况

    // 检查用户是否有特定权限
    public bool HasPermission(string userId, string permission)
    {
        if (!userPermissions.ContainsKey(userId))
# 增强安全性
        {
            return false;
        }

        return userPermissions[userId].Contains(permission);
    }

    // 获取用户所有权限
    public List<string> GetPermissions(string userId)
    {
        if (!userPermissions.ContainsKey(userId))
# 改进用户体验
        {
            return new List<string>();
        }

        return userPermissions[userId].ToList();
    }
}

// 程序入口
class Program
{
    static void Main(string[] args)
    {
        try
        {
            PermissionManager manager = new PermissionManager();

            // 添加用户权限
# 增强安全性
            manager.AddUserPermission("user1", "read");
            manager.AddUserPermission("user1", "write");
            manager.AddUserPermission("user2", "read");

            // 检查用户权限
            Console.WriteLine("User1 has 'read' permission: " + manager.HasPermission("user1", "read"));
            Console.WriteLine("User2 has 'write' permission: " + manager.HasPermission("user2", "write"));

            // 移除用户权限
            manager.RemoveUserPermission("user1", "write");

            // 获取用户所有权限
# 扩展功能模块
            var permissions = manager.GetPermissions("user1");
            Console.WriteLine("User1 permissions: " + string.Join(",", permissions));
        }
        catch (Exception ex)
# NOTE: 重要实现细节
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}
