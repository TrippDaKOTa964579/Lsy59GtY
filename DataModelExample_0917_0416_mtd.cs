// 代码生成时间: 2025-09-17 04:16:38
using System;
using System.Collections.Generic;

// DataModelExample.cs
// 此文件定义了一个简单的数据模型类，用于演示C#和.NET框架的数据模型设计。

namespace DataModelExample
{
    // 数据模型类
    public class DataModel
    {
        // 数据模型属性
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateCreated { get; set; }
        public List<string> Tags { get; set; } = new List<string>();

        // 构造函数
        public DataModel()
        {
            // 初始化DateCreated属性为当前日期和时间
            DateCreated = DateTime.Now;
        }

        // 方法：添加标签
        public void AddTag(string tag)
        {
            // 检查标签是否为空或null
            if (string.IsNullOrWhiteSpace(tag))
            {
                throw new ArgumentException("Tag cannot be null or whitespace.");
            }

            // 添加标签到Tags列表
            Tags.Add(tag);
        }

        // 方法：删除标签
        public bool RemoveTag(string tag)
        {
            // 检查标签是否存在并删除
            return Tags.Remove(tag);
        }
    }
}
