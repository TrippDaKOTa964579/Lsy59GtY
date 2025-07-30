// 代码生成时间: 2025-07-31 02:39:56
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace ProcessManagement
{
    public class ProcessManager
    {
        /// <summary>
        /// Gets a list of all running processes.
        /// </summary>
        /// <returns>A list of Process objects representing all running processes.</returns>
        public List<Process> ListProcesses()
        {
            // Get all processes running on the system
            var processes = Process.GetProcesses();
            return processes.ToList();
        }

        /// <summary>
        /// Starts a new process with the given process name.
        /// </summary>
        /// <param name="processName">The name of the process to start.</param>
        /// <returns>The started Process object, or null if an error occurred.</returns>
        public Process StartProcess(string processName)
        {
            try
            {
                // Start the process
                Process process = Process.Start(processName);
                return process;
            }
            catch (Exception ex)
            {
                // Handle any exceptions that occur during process start
                Console.WriteLine($"Error starting process {processName}: {ex.Message}");
                return null;
            }
        }

        /// <summary>
        /// Stops a process with the given process id.
        /// </summary>
        /// <param name="processId">The ID of the process to stop.</param>
        /// <returns>True if the process was successfully stopped, false otherwise.</returns>
        public bool StopProcess(int processId)
        {
            try
            {
                // Get the process by ID
                Process process = Process.GetProcessById(processId);
                // Stop the process
                process.Kill();
                return true;
            }
            catch (Exception ex)
            {
                // Handle any exceptions that occur during process stop
                Console.WriteLine($"Error stopping process {processId}: {ex.Message}");
                return false;
            }
        }
    }
}
