// 代码生成时间: 2025-09-18 15:45:25
// RestfulApiExample.cs
using Microsoft.AspNetCore.Mvc;
using System;

namespace RestfulApi
{
    // 定义Controller处理HTTP请求
    [ApiController]
    [Route("[controller]"])
    public class ItemsController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild",
            "Warm\, "Balmy", "Hot", "Sweltering", "Scorching"
        };

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                // 返回项目列表
                return Ok(Summaries);
            }
            catch (Exception ex)
            {
                // 错误处理
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                if (id < 0 || id >= Summaries.Length)
                {
                    return NotFound();
                }
                // 返回单个项目详情
                return Ok(Summaries[id]);
            }
            catch (Exception ex)
            {
                // 错误处理
                return StatusCode(500, ex.Message);
            }
        }
    }
}
