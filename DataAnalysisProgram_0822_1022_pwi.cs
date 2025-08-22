// 代码生成时间: 2025-08-22 10:22:43
using System;
using System.Collections.Generic;
using System.Linq;

// 统计数据分析器类
public class DataAnalysisProgram
{
    // 统计数据条目
    private List<double> data = new List<double>();

    // 构造函数
    public DataAnalysisProgram()
    {
    }

    // 添加数据方法
    public void AddData(double value)
    {
        if (value < 0)
        {
            throw new ArgumentException("Value cannot be negative.");
        }
        data.Add(value);
    }

    // 计算平均值
    public double CalculateMean()
    {
        try
        {
            return data.Average();
        }
        catch (InvalidOperationException)
        {
            throw new InvalidOperationException("No data available to calculate the mean.");
        }
    }

    // 计算中位数
    public double CalculateMedian()
    {
        try
        {
            int index = data.Count / 2;
            if (data.Count % 2 == 0)
            {
                return (data[index] + data[index - 1]) / 2;
            }
            else
            {
                return data[index];
            }
        }
        catch (InvalidOperationException)
        {
            throw new InvalidOperationException("No data available to calculate the median.");
        }
    }

    // 计算众数
    public double CalculateMode()
    {
        try
        {
            // 使用LINQ查找众数
            var mode = data.GroupBy(x => x)
                            .OrderByDescending(g => g.Count())
                            .First();
            return mode.Key;
        }
        catch (InvalidOperationException)
        {
            throw new InvalidOperationException("No data available to calculate the mode.");
        }
    }

    // 计算最大值
    public double CalculateMax()
    {
        try
        {
            return data.Max();
        }
        catch (InvalidOperationException)
        {
            throw new InvalidOperationException("No data available to calculate the maximum value.");
        }
    }

    // 计算最小值
    public double CalculateMin()
    {
        try
        {
            return data.Min();
        }
        catch (InvalidOperationException)
        {
            throw new InvalidOperationException("No data available to calculate the minimum value.");
        }
    }

    // 数据分析结果类
    public class AnalysisResult
    {
        public double Mean { get; set; }
        public double Median { get; set; }
        public double Mode { get; set; }
        public double Max { get; set; }
        public double Min { get; set; }
    }

    // 执行数据分析
    public AnalysisResult PerformAnalysis()
    {
        try
        {
            AnalysisResult result = new AnalysisResult
            {
                Mean = CalculateMean(),
                Median = CalculateMedian(),
                Mode = CalculateMode(),
                Max = CalculateMax(),
                Min = CalculateMin()
            };
            return result;
        }
        catch (Exception ex)
        {
            throw new Exception("An error occurred during data analysis: " + ex.Message);
        }
    }
}
