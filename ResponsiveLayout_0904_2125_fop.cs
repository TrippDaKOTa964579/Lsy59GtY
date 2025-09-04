// 代码生成时间: 2025-09-04 21:25:39
using System;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Http;

namespace ResponsiveDesignApp
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class LayoutController : ControllerBase
    {
        private readonly IWebHostEnvironment _env;

        public LayoutController(IWebHostEnvironment env)
        {
            _env = env;
        }

        // GET: /Layout/GetResponsiveLayout
        [HttpGet]
        public IActionResult GetResponsiveLayout()
        {
            try
            {
                // Here we are assuming the layout file is stored at the root of the wwwroot directory.
                var path = Path.Combine(_env.WebRootPath, "layout.html");

                if (!File.Exists(path))
                {
                    return NotFound("Layout file not found.");
                }

                string content = File.ReadAllText(path);
                return Ok(content);
            }
            catch (Exception ex)
            {
                // Log the exception details here.
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal Server Error: {ex.Message}");
            }
        }

        // GET: /Layout/GetResponsiveStylesheets
        [HttpGet]
        public IActionResult GetResponsiveStylesheets()
        {
            try
            {
                // Here we are assuming the stylesheets are stored in the wwwroot/css directory.
                var path = Path.Combine(_env.WebRootPath, "css");
                var files = Directory.GetFiles(path, "*.css");

                if (files.Length == 0)
                {
                    return NotFound("No stylesheets found.");
                }

                var stylesheetLinks = new List<string>();
                foreach (var file in files)
                {
                    var fileName = Path.GetFileName(file);
                    var link = $"<link rel="stylesheet" href="/css/{fileName}" />";
                    stylesheetLinks.Add(link);
                }

                return Ok(stylesheetLinks);
            }
            catch (Exception ex)
            {
                // Log the exception details here.
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal Server Error: {ex.Message}");
            }
        }
    }
}
