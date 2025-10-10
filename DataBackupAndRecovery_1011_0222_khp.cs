// 代码生成时间: 2025-10-11 02:22:21
using System;
using System.IO;
using System.IO.Compression;

// 该类提供了数据备份和恢复的功能
public class DataBackupAndRecovery
{
    // 备份数据到指定路径
    public static void BackupData(string sourcePath, string backupPath)
    {
        try
        {
            // 检查源路径是否存在
            if (!Directory.Exists(sourcePath))
            {
                throw new DirectoryNotFoundException($"The source directory {sourcePath} does not exist.");
            }

            // 创建备份目录
            Directory.CreateDirectory(Path.GetDirectoryName(backupPath) ?? throw new InvalidOperationException("Backup path is not valid."));

            // 使用ZIP压缩备份数据
            ZipFile.CreateFromDirectory(sourcePath, backupPath);

            Console.WriteLine($"Backup completed successfully. Data backed up to {backupPath}");
        }
        catch (Exception ex)
        {
            // 错误处理
            Console.WriteLine($"Error occurred during backup: {ex.Message}");
        }
    }

    // 从指定路径恢复数据
    public static void RestoreData(string backupPath, string targetPath)
    {
        try
        {
            // 检查备份文件是否存在
            if (!File.Exists(backupPath))
            {
                throw new FileNotFoundException($"The backup file {backupPath} does not exist.");
            }

            // 创建目标目录
            Directory.CreateDirectory(targetPath);

            // 解压备份文件到目标路径
            ZipFile.ExtractToDirectory(backupPath, targetPath);

            Console.WriteLine($"Restore completed successfully. Data restored to {targetPath}");
        }
        catch (Exception ex)
        {
            // 错误处理
            Console.WriteLine($"Error occurred during restore: {ex.Message}");
        }
    }

    // 主程序入口点
    public static void Main(string[] args)
    {
        // 示例：备份和恢复数据
        string sourcePath = @"C:\Data";
        string backupPath = @"C:\Backup.zip";
        string targetPath = @"C:\RestoredData";

        // 执行备份
        BackupData(sourcePath, backupPath);

        // 执行恢复
        RestoreData(backupPath, targetPath);
    }
}
