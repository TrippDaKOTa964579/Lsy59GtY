// 代码生成时间: 2025-08-28 03:08:53
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// 定义用户权限枚举
public enum UserPermission
{
    None = 0,
    Read = 1,
    Write = 2,
    Delete = 4,
    All = Read | Write | Delete
}

// 用户权限类
public class UserPermissionManager
{
    // 用户权限信息字典
    private Dictionary<string, UserPermission> userPermissions = new Dictionary<string, UserPermission>();

    // 添加用户权限
    public void AddUserPermission(string username, UserPermission permission)
    {
        try
        {
            if (!userPermissions.ContainsKey(username))
            {
                userPermissions.Add(username, permission);
                Console.WriteLine($"User {username} added with permission {permission}.");
            }
            else
            {
                throw new Exception($"User {username} already exists in the system.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error adding user permission: {ex.Message}");
        }
    }

    // 更新用户权限
    public void UpdateUserPermission(string username, UserPermission newPermission)
    {
        try
        {
            if (userPermissions.ContainsKey(username))
            {
                userPermissions[username] = newPermission;
                Console.WriteLine($"User {username}'s permission updated to {newPermission}.");
            }
            else
            {
                throw new Exception($"User {username} does not exist in the system.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error updating user permission: {ex.Message}");
        }
    }

    // 删除用户权限
    public void RemoveUserPermission(string username)
    {
        try
        {
            if (userPermissions.ContainsKey(username))
            {
                userPermissions.Remove(username);
                Console.WriteLine($"User {username}'s permission removed.");
            }
            else
            {
                throw new Exception($"User {username} does not exist in the system.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error removing user permission: {ex.Message}");
        }
    }

    // 检查用户是否有特定权限
    public bool CheckUserPermission(string username, UserPermission permission)
    {
        try
        {
            if (userPermissions.ContainsKey(username))
            {
                return (userPermissions[username] & permission) != UserPermission.None;
            }
            else
            {
                throw new Exception($"User {username} does not exist in the system.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error checking user permission: {ex.Message}");
            return false;
        }
    }
}

// 主程序类
public class Program
{
    public static void Main(string[] args)
    {
        UserPermissionManager manager = new UserPermissionManager();

        // 添加用户权限
        manager.AddUserPermission("Alice", UserPermission.All);
        manager.AddUserPermission("Bob", UserPermission.Read);

        // 更新用户权限
        manager.UpdateUserPermission("Bob", UserPermission.All);

        // 删除用户权限
        manager.RemoveUserPermission("Charlie");

        // 检查用户权限
        bool canRead = manager.CheckUserPermission("Bob", UserPermission.Read);
        Console.WriteLine($"Bob can read: {canRead}.");
    }
}