// 代码生成时间: 2025-08-28 11:32:59
using System;
using System.Collections.Generic;
using System.Linq;

// 引入图表库 OxyPlot
using OxyPlot;
using OxyPlot.Series;

// 交互式图表生成器类
public class InteractiveChartGenerator
{
    // 生成图表的方法
    public PlotModel GenerateChart(List<DataPoint> dataPoints)
    {
        try
        {
            // 创建一个新的图表模型
            PlotModel plotModel = new PlotModel()
            {
                Title = "Interactive Chart",
                LegendPlacement = LegendPlacement.Outside,
                LegendOrientation = LegendOrientation.Horizontal,
                LegendBorderThickness = 0
            };

            // 定义一个折线图系列
            LineSeries lineSeries = new LineSeries();

            // 添加数据点到折线图系列
            foreach (var point in dataPoints)
            {
                lineSeries.Points.Add(point);
            }

            // 添加折线图系列到图表模型
            plotModel.Series.Add(lineSeries);

            // 返回图表模型
            return plotModel;
        }
        catch (Exception ex)
        {
            // 错误处理
            Console.WriteLine($"An error occurred: {ex.Message}");
            return null;
        }
    }

    // DataPoint 类用于存储图表数据点
    public class DataPoint
    {
        public double X { get; set; }
        public double Y { get; set; }
    }
}

// 使用示例
class Program
{
    static void Main(string[] args)
    {
        // 创建交互式图表生成器实例
        InteractiveChartGenerator chartGenerator = new InteractiveChartGenerator();

        // 创建数据点列表
        List<InteractiveChartGenerator.DataPoint> dataPoints = new List<InteractiveChartGenerator.DataPoint>
        {
            new InteractiveChartGenerator.DataPoint { X = 0, Y = 5 },
            new InteractiveChartGenerator.DataPoint { X = 1, Y = 8 },
            new InteractiveChartGenerator.DataPoint { X = 2, Y = 3 },
            new InteractiveChartGenerator.DataPoint { X = 3, Y = 10 }
        };

        // 生成图表
        PlotModel plotModel = chartGenerator.GenerateChart(dataPoints);

        // 如果图表生成成功，显示图表
        if (plotModel != null)
        {
            // 使用OxyPlot提供的显示方法
            // OxyPlot.Wpf.PlotView plotView = new OxyPlot.Wpf.PlotView { Model = plotModel };
            // plotView.ShowDialog();
            Console.WriteLine("Chart generated successfully.");
        }
        else
        {
            Console.WriteLine("Failed to generate chart.");
        }
    }
}