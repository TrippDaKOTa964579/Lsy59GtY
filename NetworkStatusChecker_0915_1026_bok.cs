// 代码生成时间: 2025-09-15 10:26:45
using System;
using System.Net.Sockets;
# TODO: 优化性能
using System.Threading.Tasks;

namespace NetworkStatusChecker
{
    /// <summary>
    /// Represents a network status checker that can be used to check the
# 扩展功能模块
    /// connectivity to a given host and port.
    /// </summary>
    public class NetworkStatusChecker
# 增强安全性
    {
# FIXME: 处理边界情况
        private readonly string _host;
        private readonly int _port;

        /// <summary>
# 改进用户体验
        /// Initializes a new instance of the <see cref="NetworkStatusChecker"/> class.
        /// </summary>
        /// <param name="host">The host to check the connectivity to.</param>
        /// <param name="port">The port to check the connectivity to.</param>
        public NetworkStatusChecker(string host, int port)
        {
            _host = host ?? throw new ArgumentNullException(nameof(host));
            _port = port;
        }

        /// <summary>
        /// Checks the network connectivity to the specified host and port.
        /// </summary>
        /// <returns>A <see cref="Task{bool}