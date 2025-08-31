// 代码生成时间: 2025-08-31 23:42:01
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace PerformanceTesting
{
    /// <summary>
    /// A class for performance testing which measures the execution time of a given method.
    /// </summary>
    public class PerformanceTester
    {
        /// <summary>
        /// Measures the execution time of the provided action.
        /// </summary>
        /// <param name="action">The action to be measured.</param>
        public void MeasurePerformance(Action action)
        {
            try
            {
                // Start the stopwatch
                Stopwatch stopwatch = Stopwatch.StartNew();

                // Execute the action
                action.Invoke();

                // Stop the stopwatch
                stopwatch.Stop();

                // Print the elapsed time
                Console.WriteLine($"Execution Time: {stopwatch.ElapsedMilliseconds} ms");
            }
            catch (Exception ex)
            {
                // Handle exceptions and print the error message
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        /// <summary>
        /// Measures the execution time of the provided asynchronous function.
        /// </summary>
        /// <param name="asyncAction">The asynchronous action to be measured.</param>
        public async Task MeasurePerformanceAsync(Func<Task> asyncAction)
        {
            try
            {
                // Start the stopwatch
                Stopwatch stopwatch = Stopwatch.StartNew();

                // Execute the asynchronous action
                await asyncAction();

                // Stop the stopwatch
                stopwatch.Stop();

                // Print the elapsed time
                Console.WriteLine($"Execution Time: {stopwatch.ElapsedMilliseconds} ms");
            }
            catch (Exception ex)
            {
                // Handle exceptions and print the error message
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Create an instance of the performance tester
            PerformanceTester tester = new PerformanceTester();

            // Example action to measure
            Action exampleAction = () => {
                for (int i = 0; i < 1000000; i++)
                {
                    // Simulate some work
                    int result = i * i;
                }
            };

            // Example asynchronous action to measure
            Func<Task> exampleAsyncAction = async () =>
            {
                for (int i = 0; i < 10000; i++)
                {
                    // Simulate some work
                    await Task.Delay(10);
                    int result = i * i;
                }
            };

            // Measure the performance of the synchronous action
            Console.WriteLine("Measuring synchronous action performance...");
            tester.MeasurePerformance(exampleAction);

            // Measure the performance of the asynchronous action
            Console.WriteLine("
Measuring asynchronous action performance...");
            await tester.MeasurePerformanceAsync(exampleAsyncAction);
        }
    }
}