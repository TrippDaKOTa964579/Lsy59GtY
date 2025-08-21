// 代码生成时间: 2025-08-21 17:05:02
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace SystemPerformanceMonitor
{
    /// <summary>
    /// A utility class to monitor system performance.
    /// </summary>
    public class SystemPerformanceMonitor
    {
        private PerformanceCounter cpuCounter;
        private PerformanceCounter memoryCounter;
        private PerformanceCounter diskCounter;

        /// <summary>
        /// Initializes a new instance of the SystemPerformanceMonitor class.
        /// </summary>
        public SystemPerformanceMonitor()
        {
            // Initialize performance counters
            cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
            memoryCounter = new PerformanceCounter("Memory", "Available MBytes");
            diskCounter = new PerformanceCounter("LogicalDisk", "Free Megabytes", "C:");
        }

        /// <summary>
        /// Gets the current CPU usage as a percentage.
        /// </summary>
        /// <returns>The current CPU usage.</returns>
        public double GetCpuUsage()
        {
            return cpuCounter.NextValue();
        }

        /// <summary>
        /// Gets the current available memory in megabytes.
        /// </summary>
        /// <returns>The current available memory.</returns>
        public double GetAvailableMemory()
        {
            return memoryCounter.NextValue();
        }

        /// <summary>
        /// Gets the current free disk space on drive C in megabytes.
        /// </summary>
        /// <returns>The current free disk space.</returns>
        public double GetFreeDiskSpace()
        {
            return diskCounter.NextValue();
        }

        /// <summary>
        /// Disposes the performance counters.
        /// </summary>
        public void Dispose()
        {
            cpuCounter.Dispose();
            memoryCounter.Dispose();
            diskCounter.Dispose();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                using (var monitor = new SystemPerformanceMonitor())
                {
                    Console.WriteLine("CPU Usage: " + monitor.GetCpuUsage() + "%");
                    Console.WriteLine("Available Memory: " + monitor.GetAvailableMemory() + " MB");
                    Console.WriteLine("Free Disk Space: " + monitor.GetFreeDiskSpace() + " MB");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}