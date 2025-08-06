// 代码生成时间: 2025-08-07 01:40:37
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

// 定义一个简单的模型类，用于存储和传输数据
public class SampleModel
{
    public int Id { get; set; }
    public string Name { get; set; }
}

// 创建一个控制器类，用于处理RESTful API请求
[ApiController]
[Route("api/[controller]/[action]