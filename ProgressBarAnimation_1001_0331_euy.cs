// 代码生成时间: 2025-10-01 03:31:29
using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace ProgressBarAnimation
{
    /// <summary>
    /// Class responsible for displaying a progress bar with a loading animation.
    /// </summary>
    public class ProgressBarAnimation
    {
        private readonly int _totalSteps;
        private int _currentStep;
        private readonly int _consoleWidth;
        private bool _isFinished;

        /// <summary>
        /// Initializes a new instance of ProgressBarAnimation with the total number of steps.
        /// </summary>
        /// <param name="totalSteps">The total number of steps in the progress.</param>
        public ProgressBarAnimation(int totalSteps)
        {
            _totalSteps = totalSteps;
            _currentStep = 0;
            _consoleWidth = Console.WindowWidth;
            _isFinished = false;
        }

        /// <summary>
        /// Starts the animation and performs the steps.
        /// </summary>
        /// <param name="cancellationToken">A token to cancel the operation.</param>
        public async Task StartAsync(CancellationToken cancellationToken)
        {
            for (int step = 1; step <= _totalSteps; step++)
            {
                if (cancellationToken.IsCancellationRequested)
                {
                    _isFinished = true;
                    throw new OperationCanceledException("Progress was cancelled.");
                }

                _currentStep = step;
                UpdateProgress();

                // Simulate work by waiting
                await Task.Delay(100, cancellationToken);
            }

            _isFinished = true;
            Console.WriteLine("
Progress completed.");
        }

        /// <summary>
        /// Updates the progress bar in the console.
        /// </summary>
        private void UpdateProgress()
        {
            // Calculate the number of characters to display for the progress
            int progressLength = (int)(_currentStep / (double)_totalSteps * _consoleWidth);
            string progress = new string('=', progressLength) + new string(' ', _consoleWidth - progressLength);

            // Write the progress bar and the loading animation
            Console.CursorLeft = 0;
            Console.Write($"Progress: {progress} {_currentStep}/{_totalSteps} ■"); // ■ is the loading animation character

            // Clear the loading animation for the next iteration
            if (_isFinished)
            {
                Console.CursorLeft = _consoleWidth - 1;
                Console.Write(' ');
            }
        }
    }

    class Program
    {
        static async Task Main(string[] args)
        {
            try
            {
                int totalSteps = 100; // Define the total number of steps
                using (CancellationTokenSource cts = new CancellationTokenSource())
                {
                    Console.CancelKeyPress += (sender, e) => cts.Cancel(); // Handle cancel key press

                    ProgressBarAnimation progress = new ProgressBarAnimation(totalSteps);
                    await progress.StartAsync(cts.Token);
                }
            }
            catch (OperationCanceledException)
            {
                Console.WriteLine("
Progress was cancelled by the user.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}
