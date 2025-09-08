// 代码生成时间: 2025-09-08 23:10:39
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace FileSyncUtility
{
    // Class for file synchronization and backup
    public class FileSyncTool
    {
        private readonly string sourcePath;
        private readonly string targetPath;

        public FileSyncTool(string source, string target)
        {
            sourcePath = source;
            targetPath = target;
        }

        // Synchronizes the files from source to target directory
        public void SynchronizeFiles()
        {
            try
            {
                // Get the list of files in the source directory
                var sourceFiles = Directory.GetFiles(sourcePath).Select(Path.GetFileName).ToList();

                // Get the list of files in the target directory
                var targetFiles = Directory.GetFiles(targetPath).Select(Path.GetFileName).ToList();

                // Find files to copy from source to target
                var filesToCopy = sourceFiles.Except(targetFiles).ToList();

                foreach (var file in filesToCopy)
                {
                    string sourceFile = Path.Combine(sourcePath, file);
                    string targetFile = Path.Combine(targetPath, file);

                    // Copy the file to the target directory
                    File.Copy(sourceFile, targetFile, true);

                    Console.WriteLine($"Copied {file} from {sourcePath} to {targetPath}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        // Backups the files from source to a backup directory
        public void BackupFiles()
        {
            try
            {
                // Create a unique backup directory based on the current timestamp
                string backupPath = Path.Combine(targetPath, $"Backup_{DateTime.Now:yyyyMMddHHmmss}");
                Directory.CreateDirectory(backupPath);

                // Get the list of files in the source directory
                var filesToBackup = Directory.GetFiles(sourcePath);

                foreach (var file in filesToBackup)
                {
                    string fileName = Path.GetFileName(file);
                    string backupFile = Path.Combine(backupPath, fileName);

                    // Copy the file to the backup directory
                    File.Copy(file, backupFile, true);

                    Console.WriteLine($"Backed up {fileName} to {backupPath}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("FileSyncTool - File Backup and Synchronization Utility
");

            // Define the source and target directories
            string sourceDir = @"C:\sourceDir";
            string targetDir = @"D:	argetDir";
            string backupDir = @"E:\backupDir";

            // Create an instance of FileSyncTool
            FileSyncTool tool = new FileSyncTool(sourceDir, targetDir);

            // Synchronize files
            tool.SynchronizeFiles();

            // Backup files
            tool.BackupFiles();
        }
    }
}