// 代码生成时间: 2025-08-06 07:28:36
// InteractiveChartGenerator.cs
// 该文件定义了一个交互式图表生成器的类，允许用户输入数据并生成图表。
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// 引入OxyPlot库，用于生成图表
using OxyPlot;
using OxyPlot.Series;
using OxyPlot.Axes;

namespace InteractiveChartGenerator
{
    // 定义一个类，用于表示图表数据
    public class ChartData
    {
        public string Category { get; set; }
        public double Value { get; set; }
    }

    // 定义主程序类，包含交互式图表生成器的方法
    public class Program
    {
        // 主函数，程序入口点
        public static void Main(string[] args)
        {
            Console.WriteLine("Interactive Chart Generator");

            // 初始化图表数据列表
            List<ChartData> chartData = new List<ChartData>();

            // 获取用户输入
            Console.Write("Enter the number of data points: ");
            if (int.TryParse(Console.ReadLine(), out int numberOfDataPoints))
            {
                for (int i = 0; i < numberOfDataPoints; i++)
                {
                    Console.Write($"
Enter category for point {i + 1}: ");
                    string category = Console.ReadLine();

                    Console.Write($"Enter value for {category}: ");
                    if (double.TryParse(Console.ReadLine(), out double value))
                    {
                        chartData.Add(new ChartData { Category = category, Value = value });
                    }
                    else
                    {
                        Console.WriteLine("Invalid value entered. Please enter a valid number.");
                        i--; // 重新请求输入
                    }
                }
            }
            else
            {
                Console.WriteLine("Invalid number of data points. Please enter a valid integer.");
                return;
            }

            // 生成图表
            GenerateChart(chartData);
        }

        // 方法：生成图表
        public static void GenerateChart(List<ChartData> data)
        {
            // 创建一个新的图表模型
            var model = new PlotModel { Title = "Interactive Chart" };

            // 添加一个柱状图系列
            var series = new ColumnSeries
            {
                Title = "Category Values",
                StrokeColor = OxyColors.Black,
                StrokeThickness = 1
            };

            // 填充系列数据
            foreach (var item in data)
            {
                series.Items.Add(new ColumnItem { Value = item.Value, Category = item.Category });
            }

            // 添加系列到模型
            model.Series.Add(series);

            // 添加类别轴和数值轴
            model.Axes.Add(new CategoryAxis { Position = AxisPosition.Bottom, Title = "Categories" });
            model.Axes.Add(new LinearAxis { Position = AxisPosition.Left, Title = "Values" });

            // 显示图表（在控制台应用程序中，这只是一个示例，实际显示需要GUI或Web环境）
            Console.WriteLine("Chart generated successfully.");

            // 存储图表到文件（示例：保存为PNG文件）
            model.Save("InteractiveChart.png", OxyPlot.OxyPlotImageFormat.Png);
            Console.WriteLine("Chart saved as InteractiveChart.png");
        }
    }
}
