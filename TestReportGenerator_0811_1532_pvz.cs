// 代码生成时间: 2025-08-11 15:32:01
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TestReporting
{
    // Define an enumeration for the report format
    public enum ReportFormat
    {
        Html,
        Txt
    }

    // Define a class for test results
    public class TestResult
    {
        public string TestName { get; set; }
        public bool IsPassed { get; set; }
        public string ErrorMessage { get; set; }
    }

    // Define the TestReportGenerator class
    public class TestReportGenerator
    {
        private readonly List<TestResult> _testResults;
        private readonly ReportFormat _reportFormat;

        // Constructor
        public TestReportGenerator(ReportFormat reportFormat)
        {
            _testResults = new List<TestResult>();
            _reportFormat = reportFormat;
        }

        // Method to add a test result to the report
        public void AddTestResult(TestResult result)
        {
            _testResults.Add(result);
        }

        // Method to generate the report based on the specified format
        public string GenerateReport()
        {
            switch (_reportFormat)
            {
                case ReportFormat.Html:
                    return GenerateHtmlReport();
                case ReportFormat.Txt:
                    return GenerateTextReport();
                default:
                    throw new InvalidOperationException("Unsupported report format");
            }
        }

        // Private method to generate a HTML report
        private string GenerateHtmlReport()
        {
            var htmlBuilder = new StringBuilder();
            htmlBuilder.Append("<html><head><title>Test Report</title></head><body>");
            htmlBuilder.AppendFormat("<h1>Test Report</h1><ul>");
            foreach (var result in _testResults)
            {
                htmlBuilder.AppendFormat("<li>{0} - {1}</li>", result.TestName, result.IsPassed ? "Passed" : "Failed");
            }
            htmlBuilder.AppendFormat("</ul></body></html>");
            return htmlBuilder.ToString();
        }

        // Private method to generate a text report
        private string GenerateTextReport()
        {
            var textBuilder = new StringBuilder();
            textBuilder.AppendLine("Test Report");
            foreach (var result in _testResults)
            {
                textBuilder.AppendLine($