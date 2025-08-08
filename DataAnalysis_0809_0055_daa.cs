// 代码生成时间: 2025-08-09 00:55:41
using System;
using System.Collections.Generic;

namespace DataAnalysisApp
{
    // 数据统计分析器类
    public class DataAnalysis
    {
        private List<double> data;

        // 构造函数
        public DataAnalysis(List<double> inputData)
        {
            if (inputData == null)
            {
                throw new ArgumentNullException("Input data cannot be null.");
            }

            data = inputData;
        }

        // 计算平均值
        public double CalculateAverage()
        {
            if (data.Count == 0)
            {
                throw new InvalidOperationException("Data list is empty.");
            }

            double sum = 0;
            foreach (double num in data)
            {
                sum += num;
            }

            return sum / data.Count;
        }

        // 计算最大值
        public double CalculateMax()
        {
            if (data.Count == 0)
            {
                throw new InvalidOperationException("Data list is empty.");
            }

            double max = double.MinValue;
            foreach (double num in data)
            {
                if (num > max)
                {
                    max = num;
                }
            }

            return max;
        }

        // 计算最小值
        public double CalculateMin()
        {
            if (data.Count == 0)
            {
                throw new InvalidOperationException("Data list is empty.");
            }

            double min = double.MaxValue;
            foreach (double num in data)
            {
                if (num < min)
                {
                    min = num;
                }
            }

            return min;
        }

        // 计算中位数
        public double CalculateMedian()
        {
            if (data.Count == 0)
            {
                throw new InvalidOperationException("Data list is empty.");
            }

            int size = data.Count;
            var sortedData = new List<double>(data);
            sortedData.Sort();

            if (size % 2 == 0)
            {
                return (sortedData[size / 2] + sortedData[size / 2 - 1]) / 2;
            }
            else
            {
                return sortedData[size / 2];
            }
        }

        // 添加数据点
        public void AddDataPoint(double value)
        {
            data.Add(value);
        }
    }

    // 主程序类
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // 示例数据集
                List<double> myData = new List<double> { 1.5, 2.5, 3.5, 4.5, 5.5 };

                // 创建数据分析器实例
                DataAnalysis analysis = new DataAnalysis(myData);

                // 执行分析
                double average = analysis.CalculateAverage();
                double max = analysis.CalculateMax();
                double min = analysis.CalculateMin();
                double median = analysis.CalculateMedian();

                Console.WriteLine("Average: " + average);
                Console.WriteLine("Max: " + max);
                Console.WriteLine("Min: " + min);
                Console.WriteLine("Median: " + median);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
