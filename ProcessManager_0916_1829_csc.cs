// 代码生成时间: 2025-09-16 18:29:12
using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;

namespace ProcessManagerApp
{
    /// <summary>
    /// A class to manage and interact with system processes.
    /// </summary>
    public class ProcessManager
    {
        // List to hold all the processes
        private List<Process> processesList;

        /// <summary>
        /// Initializes a new instance of the ProcessManager class.
        /// </summary>
        public ProcessManager()
        {
            processesList = new List<Process>();
        }

        /// <summary>
        /// Starts a new process with the specified process name.
        /// </summary>
        /// <param name="processName">The name of the process to start.</param>
        public void StartProcess(string processName)
        {
            try
            {
                ProcessStartInfo startInfo = new ProcessStartInfo(processName);
                Process process = Process.Start(startInfo);
                processesList.Add(process);
                Console.WriteLine($"Process {processName} started with ID {process.Id}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to start process {processName}. Error: {ex.Message}");
            }
        }

        /// <summary>
        /// Kills a process with the specified ID.
        /// </summary>
        /// <param name="processId">The ID of the process to kill.</param>
        public void KillProcess(int processId)
        {
            try
            {
                Process process = processesList.FirstOrDefault(p => p.Id == processId);
                if (process != null)
                {
                    process.Kill();
                    process.WaitForExit();
                    processesList.Remove(process);
                    Console.WriteLine($"Process with ID {processId} has been killed.");
                }
                else
                {
                    Console.WriteLine($"No process found with ID {processId}.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to kill process {processId}. Error: {ex.Message}");
            }
        }

        /// <summary>
        /// Lists all currently running processes.
        /// </summary>
        public void ListProcesses()
        {
            Console.WriteLine("Current running processes: ");
            foreach (var process in processesList)
            {
                Console.WriteLine($"ID: {process.Id}, Name: {process.ProcessName}, MainModule.FileName: {process.MainModule.FileName}");
            }
        }

        // Main method for testing
        public static void Main(string[] args)
        {
            ProcessManager manager = new ProcessManager();
            // Start a new process
            manager.StartProcess("notepad.exe");
            // List all processes
            manager.ListProcesses();
            // Kill the process
            manager.KillProcess(manager.processesList.FirstOrDefault().Id);
        }
    }
}