// 代码生成时间: 2025-09-03 22:59:04
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;

// 测试报告生成器类
public class TestReportGenerator
{
    // 构造函数
    public TestReportGenerator(string testResultsPath)
    {
        TestResultsPath = testResultsPath;
    }

    // 测试结果文件路径
    private string TestResultsPath { get; }

    // 生成测试报告
    public void GenerateReport(string reportPath)
    {
        try
        {
            // 读取测试结果文件
            XmlDocument testResults = new XmlDocument();
            testResults.Load(TestResultsPath);

            // 解析测试结果
            XmlNodeList testSuites = testResults.DocumentElement.SelectNodes("//test-suite");
            int totalTests = 0, failedTests = 0;
            foreach (XmlNode testSuite in testSuites)
            {
                totalTests += int.Parse(testSuite.Attributes["tests"].Value);
                failedTests += int.Parse(testSuite.Attributes["failures"].Value);
            }

            // 生成报告内容
            using (StreamWriter writer = new StreamWriter(reportPath))
            {
                writer.WriteLine("<html>");
                writer.WriteLine("<head><title>Test Report</title></head>");
                writer.WriteLine("<body>");
                writer.WriteLine($"<h1>Total Tests: {totalTests}</h1>");
                writer.WriteLine($"<h1>Failed Tests: {failedTests}</h1>");
                writer.WriteLine("<table border='1'>");
                writer.WriteLine("<tr><th>Test Case</th><th>Result</th></tr>");

                foreach (XmlNode testSuite in testSuites)
                {
                    XmlNodeList testCases = testSuite.SelectNodes("test-case");
                    foreach (XmlNode testCase in testCases)
                    {
                        string testCaseName = testCase.Attributes["name"].Value;
                        string result = testCase.Attributes["status"].Value;
                        writer.WriteLine($"<tr><td>{testCaseName}</td><td>{result}</td></tr>");
                    }
                }

                writer.WriteLine("</table>");
                writer.WriteLine("</body>");
                writer.WriteLine("</html>");
            }

            Console.WriteLine("Report generated successfully!");
        }
        catch (Exception ex)
        {
            // 错误处理
            Console.WriteLine($"Error generating report: {ex.Message}");
        }
    }
}

// 示例用法
class Program
{
    static void Main()
    {
        string testResultsPath = "test-results.xml";
        string reportPath = "test-report.html";

        TestReportGenerator generator = new TestReportGenerator(testResultsPath);
        generator.GenerateReport(reportPath);
    }
}