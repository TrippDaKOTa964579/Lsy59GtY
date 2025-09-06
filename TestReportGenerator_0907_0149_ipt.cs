// 代码生成时间: 2025-09-07 01:49:14
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

/// <summary>
/// The TestReportGenerator class is designed to generate test reports.
/// </summary>
public class TestReportGenerator
{
    private const string ReportTemplate = "ReportTemplate.txt";
    private const string TestResultsPath = "TestResults";
    private const string ReportOutputPath = "TestReports";
    private const string ReportFileName = "TestReport.html";

    /// <summary>
    /// Generates the test report based on test results stored in a directory.
    /// </summary>
    /// <param name="testResultsDirectory">Path to the directory containing test results.</param>
    public void GenerateTestReport(string testResultsDirectory)
    {
        try
        {
            // Check if the test results directory exists
            if (!Directory.Exists(testResultsDirectory))
            {
                throw new DirectoryNotFoundException("Test results directory not found.");
            }

            // Read the report template
            string templateContent = File.ReadAllText(ReportTemplate);

            // Get all test result files in the directory
            string[] testResultFiles = Directory.GetFiles(testResultsDirectory, "*.xml");
            if (testResultFiles.Length == 0)
            {
                throw new FileNotFoundException("No test result files found.");
            }

            // Parse test results and generate report content
            StringBuilder reportContent = new StringBuilder();
            foreach (var file in testResultFiles)
            {
                reportContent.Append(ParseTestResultFile(file));
            }

            // Replace placeholders in the template with actual report content
            string report = templateContent.Replace("{{TestResults}}", reportContent.ToString());

            // Create the output directory if it doesn't exist
            Directory.CreateDirectory(ReportOutputPath);

            // Write the report to a file
            File.WriteAllText(Path.Combine(ReportOutputPath, ReportFileName), report);

            Console.WriteLine("Test report generated successfully.");
        }
        catch (Exception ex)
        {
            // Log or handle any exceptions
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }

    /// <summary>
    /// Parses a test result file and returns the corresponding report content.
    /// </summary>
    /// <param name="testResultFilePath">Path to the test result file.</param>
    /// <returns>The content to be included in the test report.</returns>
    private string ParseTestResultFile(string testResultFilePath)
    {
        try
        {
            string content = File.ReadAllText(testResultFilePath);
            // This is a placeholder for actual parsing logic.
            // In a real-world scenario, you would parse the XML file and extract relevant test data.
            return $"<h2>Test File: {Path.GetFileName(testResultFilePath)}</h2>
<div>{content}</div>";
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error parsing test result file: {ex.Message}");
            return string.Empty;
        }
    }
}
