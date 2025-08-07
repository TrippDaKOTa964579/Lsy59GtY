// 代码生成时间: 2025-08-07 20:57:33
using System;
using System.Collections.Generic;
using System.Linq;

// DataAnalyzer.cs 文件包含了一个简单的数据统计分析器
public class DataAnalyzer
{
    // 存储数据的列表
    private List<int> dataList = new List<int>();

    // 添加数据到分析器
    public void AddData(int data)
    {
        dataList.Add(data);
    }

    // 计算平均值
    public double CalculateAverage()
    {
        if (dataList.Count == 0)
        {
            throw new InvalidOperationException("Data list is empty.");
        }

        return dataList.Average();
    }

    // 计算最大值
    public int CalculateMax()
    {
        if (dataList.Count == 0)
        {
            throw new InvalidOperationException("Data list is empty.");
        }

        return dataList.Max();
    }

    // 计算最小值
    public int CalculateMin()
    {
        if (dataList.Count == 0)
        {
            throw new InvalidOperationException("Data list is empty.");
        }

        return dataList.Min();
    }

    // 计算中位数
    public double CalculateMedian()
    {
        if (dataList.Count == 0)
        {
            throw new InvalidOperationException("Data list is empty.");
        }

        var sortedList = dataList.OrderBy(x => x).ToList();
        int mid = sortedList.Count / 2;
        if (sortedList.Count % 2 == 0)
        {
            return (sortedList[mid - 1] + sortedList[mid]) / 2.0;
        }
        else
        {
            return sortedList[mid];
        }
    }

    // 清除所有数据
    public void ClearData()
    {
        dataList.Clear();
    }
}
