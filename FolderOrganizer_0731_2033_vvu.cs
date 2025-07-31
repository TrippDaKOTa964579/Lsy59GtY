// 代码生成时间: 2025-07-31 20:33:01
 * A program that organizes a folder structure by moving files into
 * subfolders based on a specific pattern or criteria.
 */
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace FolderOrganizer
{
    public class Program
    {
        // Entry point of the application
        public static void Main(string[] args)
        {
            if (args.Length < 1)
            {
                Console.WriteLine("Please provide the path to the folder you want to organize.");
                return;
            }

            string folderPath = args[0];
            if (!Directory.Exists(folderPath))
            {
                Console.WriteLine($"The folder at {folderPath} does not exist.");
                return;
            }

            try
            {
                OrganizeFolder(folderPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        // Method to organize the folder
        private static void OrganizeFolder(string folderPath)
        {
            Console.WriteLine($"Starting to organize folder: {folderPath}");

            // Get all files from the specified folder
            IEnumerable<string> files = Directory.GetFiles(folderPath).ToList();

            // Create a dictionary to hold file extensions as keys and lists of file paths as values
            var fileGroups = files
                .Select(Path.GetFileName)
                .GroupBy(Path.GetExtension)
                .ToDictionary(group => group.Key, group => group.Select(f => Path.Combine(folderPath, f)).ToList());

            // Create subfolders and move files into them
            foreach (var fileGroup in fileGroups)
            {
                string subfolderName = Path.GetFileNameWithoutExtension(fileGroup.Key);
                string subfolderPath = Path.Combine(folderPath, subfolderName);

                // Create the subfolder if it does not exist
                if (!Directory.Exists(subfolderPath))
                {
                    Directory.CreateDirectory(subfolderPath);
                }

                // Move files into the subfolder
                foreach (var filePath in fileGroup.Value)
                {
                    File.Move(filePath, Path.Combine(subfolderPath, Path.GetFileName(filePath)));
                }
            }

            Console.WriteLine($"Folder organization completed.");
        }
    }
}
