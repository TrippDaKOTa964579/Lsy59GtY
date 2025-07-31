// 代码生成时间: 2025-07-31 15:17:31
using System;
using System.Diagnostics;
using System.Linq;

namespace ProcessManagerApp
{
    /// <summary>
    /// A class to manage and interact with system processes.
    /// </summary>
    public class ProcessManager
    {
        /// <summary>
        /// Gets a list of all active processes on the system.
        /// </summary>
        /// <returns>A list of Process objects.</returns>
        public static Process[] GetAllProcesses()
        {
            try
            {
                return Process.GetProcesses();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error retrieving processes: " + ex.Message);
                return null;
            }
        }

        /// <summary>
        /// Starts a new process with the specified process name.
        /// </summary>
        /// <param name="processName">The name of the process to start.</param>
        public static void StartProcess(string processName)
        {
            try
            {
                Process.Start(processName);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error starting process: " + ex.Message);
            }
        }

        /// <summary>
        /// Kills a process by its name.
        /// </summary>
        /// <param name="processName">The name of the process to kill.</param>
        public static void KillProcess(string processName)
        {
            try
            {
                var processes = Process.GetProcessesByName(processName);
                foreach (var process in processes)
                {
                    process.Kill();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error killing process: " + ex.Message);
            }
        }

        /// <summary>
        /// Main method for demonstration purposes.
        /// </summary>
        public static void Main(string[] args)
        {
            // Display all processes
            var processes = GetAllProcesses();
            if (processes != null)
            {
                foreach (var process in processes)
                {
                    Console.WriteLine("Process Name: " + process.ProcessName + ", ID: " + process.Id);
                }
            }

            // Start a new process (e.g., notepad)
            StartProcess("notepad");

            // Kill a process by name (e.g., notepad), wait for a few seconds to ensure it's started
            System.Threading.Thread.Sleep(5000);
            KillProcess("notepad");
        }
    }
}