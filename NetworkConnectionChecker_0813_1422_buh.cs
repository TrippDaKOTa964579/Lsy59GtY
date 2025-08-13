// 代码生成时间: 2025-08-13 14:22:46
using System;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace NetworkChecker
{
    /// <summary>
    /// Represents a network connection status checker.
    /// </summary>
    public class NetworkConnectionChecker
    {
        private readonly string _host;
        private readonly int _port;

        /// <summary>
        /// Initializes a new instance of the <see cref="NetworkConnectionChecker"/> class.
        /// </summary>
        /// <param name="host">The host to check the connection with.</param>
        /// <param name="port">The port to check the connection on.</param>
        public NetworkConnectionChecker(string host, int port)
        {
            _host = host ?? throw new ArgumentNullException(nameof(host));
            _port = port;
        }

        /// <summary>
        /// Checks the network connection status asynchronously.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.
        /// The task result indicates whether the network connection is available.</returns>
        public async Task<bool> CheckConnectionAsync()
        {
            try
            {
                using (var client = new TcpClient())
                {
                    await client.ConnectAsync(_host, _port);
                    return true;
                }
            }
            catch (SocketException e)
            {
                Console.WriteLine($"SocketException: {e.Message}");
                return false;
            }
            catch (Exception e)
            {
                Console.WriteLine($"An error occurred: {e.Message}");
                return false;
            }
        }
    }

    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Checking network connection...");
            var checker = new NetworkConnectionChecker("www.google.com", 80);
            bool isConnected = await checker.CheckConnectionAsync();

            if (isConnected)
            {
                Console.WriteLine("Network connection is available.");
            }
            else
            {
                Console.WriteLine("Network connection is not available.");
            }
        }
    }
}