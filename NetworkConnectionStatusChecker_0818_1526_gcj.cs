// 代码生成时间: 2025-08-18 15:26:56
using System;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace NetworkStatusChecker
{
    /// <summary>
    /// A class responsible for checking the network connection status.
    /// </summary>
    public class NetworkConnectionStatusChecker
    {
        private readonly string _host;
        private readonly int _port;

        /// <summary>
        /// Initializes a new instance of the <see cref="NetworkConnectionStatusChecker"/> class.
        /// </summary>
        /// <param name="host">The hostname or IP address to check.</param>
        /// <param name="port">The port number to check.</param>
        public NetworkConnectionStatusChecker(string host, int port)
        {
            _host = host ?? throw new ArgumentNullException(nameof(host));
            _port = port;
        }

        /// <summary>
        /// Asynchronously checks the network connection status.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation. The task result indicates whether the connection is successful.</returns>
        public async Task<bool> CheckConnectionAsync()
        {
            try
            {
                using (var client = new TcpClient())
                {
                    // Attempt to connect to the specified host and port
                    await client.ConnectAsync(_host, _port);
                    return client.Connected;
                }
            }
            catch (SocketException ex)
            {
                // Log the exception details and return false indicating the connection failed
                Console.WriteLine($"Connection failed: {ex.Message}");
                return false;
            }
            catch (Exception ex)
            {
                // Log any other exceptions and return false indicating the connection failed
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
                return false;
            }
        }
    }

    /// <summary>
    /// A simple example of how to use the NetworkConnectionStatusChecker class.
    /// </summary>
    class Program
    {
        static async Task Main(string[] args)
        {
            var checker = new NetworkConnectionStatusChecker("www.google.com", 80);
            bool isConnected = await checker.CheckConnectionAsync();
            Console.WriteLine(isConnected ? "Connected" : "Not connected");
        }
    }
}