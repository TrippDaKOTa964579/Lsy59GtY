// 代码生成时间: 2025-08-24 23:25:39
using System;
using System.IO;
using System.Windows.Forms;
using ClosedXML.Excel;

namespace ExcelGeneratorApp
{
    /// <summary>
    /// Class responsible for generating Excel files.
    /// </summary>
    public class ExcelGenerator
    {
        private string _filePath;

        /// <summary>
        /// Initializes a new instance of ExcelGenerator.
        /// </summary>
        /// <param name="filePath">The path where the Excel file will be saved.</param>
        public ExcelGenerator(string filePath)
        {
            _filePath = filePath;
        }

        /// <summary>
        /// Generates an Excel file with specified data.
        /// </summary>
        /// <param name="data">The data to be written in the Excel file.</param>
        public void GenerateExcelFile(object[,] data)
        {
            try
            {
                using (var workbook = new XLWorkbook())
                {
                    var worksheet = workbook.Worksheets.Add("Sheet1");

                    for (int row = 1; row <= data.GetLength(0); row++)
                    {
                        for (int col = 1; col <= data.GetLength(1); col++)
                        {
                            worksheet.Cell(row, col).Value = data[row - 1, col - 1];
                        }
                    }

                    workbook.SaveAs(_filePath);
                }
            }
            catch (Exception ex)
            {
                // Log the error or handle it as per the application requirement.
                MessageBox.Show("Error occurred: " + ex.Message);
            }
        }
    }

    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
