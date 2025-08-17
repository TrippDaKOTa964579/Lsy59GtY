// 代码生成时间: 2025-08-18 07:03:27
 * and reorganize the files into a structured folder layout.
 *
 * Author: [Your Name]
 * Date: [Today's Date]
 */
using System;
using System.IO;
using System.Linq;

namespace FolderOrganizer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Check if the user provided a directory path
            if (args.Length == 0)
            {
                Console.WriteLine("Please provide a directory path as an argument.");
                return;
            }

            string directoryPath = args[0];
            if (!Directory.Exists(directoryPath))
            {
                Console.WriteLine("The specified directory does not exist.");
                return;
            }

            try
            {
                OrganizeDirectory(directoryPath);
                Console.WriteLine("Directory organization complete.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        // Method to organize the files in the directory
        private static void OrganizeDirectory(string directoryPath)
        {
            // Define the root of the directory where files will be organized
            string rootDirectory = Path.Combine(directoryPath, "Organized");
            Directory.CreateDirectory(rootDirectory);

            // Get all files in the directory, including subdirectories
            var files = Directory.GetFiles(directoryPath, "*", SearchOption.AllDirectories);

            foreach (string file in files)
            {
                // Skip if the file is already in the organized directory
                if (file.StartsWith(rootDirectory)) continue;

                // Determine the new path for the file based on its extension
                string newDirectory = Path.Combine(rootDirectory, Path.GetExtension(file).Trim('.'));
                Directory.CreateDirectory(newDirectory);

                // Move the file to the new directory
                string newFilePath = Path.Combine(newDirectory, Path.GetFileName(file));
                File.Move(file, newFilePath);
            }
        }
    }
}