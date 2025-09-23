// 代码生成时间: 2025-09-23 09:05:58
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace PerformanceTesting
{
    // 性能测试脚本类
    public class PerformanceTestingScript
    {
        private readonly string targetUrl;

        public PerformanceTestingScript(string targetUrl)
        {
            // 确保传入的URL不为空
            if (string.IsNullOrWhiteSpace(targetUrl))
                throw new ArgumentException("Target URL cannot be null or whitespace.", nameof(targetUrl));

            this.targetUrl = targetUrl;
        }

        // 执行性能测试的方法
        public List<TimeSpan> TestWebPerformance(int numberOfRequests, int delayBetweenRequests)
        {
            List<TimeSpan> responseTimes = new List<TimeSpan>();
            List<Task> tasks = new List<Task>();

            for (int i = 0; i < numberOfRequests; i++)
            {
                // 为每个请求创建一个任务
                tasks.Add(Task.Run(async () =>
                {
                    try
                    {
                        // 模拟延迟
                        if (delayBetweenRequests > 0)
                            await Task.Delay(delayBetweenRequests);

                        // 测量请求的执行时间
                        var stopWatch = Stopwatch.StartNew();
                        var response = await new HttpClient().GetAsync(targetUrl);
                        response.EnsureSuccessStatusCode();
                        stopWatch.Stop();

                        // 添加响应时间到列表
                        responseTimes.Add(stopWatch.Elapsed);
                    }
                    catch (Exception ex)
                    {
                        // 错误处理
                        Console.WriteLine($"Error during request: {ex.Message}");
                    }
                }));
            }

            // 等待所有任务完成
            Task.WhenAll(tasks).Wait();

            return responseTimes;
        }
    }
}
