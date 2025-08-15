// 代码生成时间: 2025-08-16 00:07:39
using System;
using System.Data;
using System.IO;
using ClosedXML.Excel;

namespace ExcelGeneratorApp
{
    // Excel表格自动生成器
    public class ExcelGenerator
    {
        /// <summary>
        /// 生成Excel文件
        /// </summary>
        /// <param name="data">要写入Excel的数据</param>
        /// <param name="filePath">保存Excel文件的路径</param>
        /// <returns>生成文件的路径</returns>
        public string GenerateExcel(DataTable data, string filePath)
        {
            // 检查数据是否为空
            if (data == null || data.Rows.Count == 0)
            {
                throw new ArgumentException("No data to write into Excel.");
            }

            // 检查文件路径是否有效
            if (string.IsNullOrWhiteSpace(filePath))
            {
                throw new ArgumentException("File path cannot be empty.");
            }

            try
            {
                // 创建Excel工作簿
                using (var workbook = new XLWorkbook())
                {
                    // 添加一个工作表
                    var worksheet = workbook.Worksheets.Add(data.TableName ?? "Sheet1");

                    // 将数据写入工作表
                    worksheet.Row(1).InsertRangeFromTable(data);

                    // 保存Excel文件
                    workbook.SaveAs(filePath);

                    // 返回文件路径
                    return filePath;
                }
            }
            catch (Exception ex)
            {
                // 错误处理
                Console.WriteLine($"An error occurred: {ex.Message}");
                throw;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // 创建Excel生成器实例
            var excelGenerator = new ExcelGenerator();

            // 创建一个示例DataTable
            var dataTable = new DataTable();
            dataTable.Columns.Add("Name", typeof(string));
            dataTable.Columns.Add("Age", typeof(int));

            // 添加示例数据
            dataTable.Rows.Add("John", 30);
            dataTable.Rows.Add("Jane", 25);

            // 设置Excel文件保存路径
            string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Example.xlsx");

            // 生成Excel文件
            string generatedFilePath = excelGenerator.GenerateExcel(dataTable, filePath);

            // 显示生成文件的路径
            Console.WriteLine($"Excel file generated at: {generatedFilePath}");
        }
    }
}