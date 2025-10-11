// 代码生成时间: 2025-10-11 20:06:40
// HTTP请求处理器
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;

namespace HttpRequestHandler
{
    public class HttpService : IHostedService
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl;

        public HttpService(string baseUrl)
        {
            _httpClient = new HttpClient();
            _baseUrl = baseUrl;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine("HTTP服务启动...");
            await ProcessRequestsAsync(cancellationToken);
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine("HTTP服务停止...");
            return Task.CompletedTask;
        }

        private async Task ProcessRequestsAsync(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                try
                {
                    using (var response = await _httpClient.GetAsync(_baseUrl))
                    {
                        response.EnsureSuccessStatusCode();
                        string responseBody = await response.Content.ReadAsStringAsync();
                        Console.WriteLine("Response: " + responseBody);
                    }
                }
                catch (HttpRequestException ex)
                {
                    Console.WriteLine("请求异常: " + ex.Message);
                    break;
                }
                catch (TaskCanceledException ex)
                {
                    Console.WriteLine("请求被取消: 