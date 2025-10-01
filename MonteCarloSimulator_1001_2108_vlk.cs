// 代码生成时间: 2025-10-01 21:08:56
using System;
using System.Threading.Tasks;
using System.Numerics;

namespace MonteCarloSimulation
{
    /// <summary>
    /// Represents a Monte Carlo simulator for estimating mathematical probabilities.
    /// </summary>
    public class MonteCarloSimulator
    {
        private readonly int _iterations;
        private readonly Random _random;

        /// <summary>
        /// Initializes a new instance of the MonteCarloSimulator class.
        /// </summary>
        /// <param name="iterations">The number of simulations to run.</param>
        public MonteCarloSimulator(int iterations)
        {
            _iterations = iterations;
            _random = new Random();
        }

        /// <summary>
        /// Simulates a mathematical experiment and returns the probability estimate.
        /// </summary>
        /// <param name="experimentFunc">A function representing the experiment.</param>
        /// <returns>The estimated probability of the experiment.</returns>
        public double Simulate(Func<int, bool> experimentFunc)
        {
            if (experimentFunc == null)
                throw new ArgumentNullException(nameof(experimentFunc));

            int successfulOutcomes = 0;

            for (int i = 0; i < _iterations; i++)
            {
                successfulOutcomes += experimentFunc(_random.Next());
            }

            return (double)successfulOutcomes / _iterations;
        }
    }

    class Program
    {
        static async Task Main(string[] args)
        {
            try
            {
                MonteCarloSimulator simulator = new MonteCarloSimulator(1000000);
                double probability = await Task.Run(() => simulator.Simulate(EstimatePi));

                Console.WriteLine($"Estimated Pi value: {probability * 4:F4}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        /// <summary>
        /// A simple experiment to estimate the value of Pi using the Monte Carlo method.
        /// </summary>
        /// <param name="rand">A random number generator.</param>
        /// <returns>True if the point is inside a circle, false otherwise.</returns>
        static bool EstimatePi(int rand)
        {
            double x = rand / 1000000.0;
            double y = rand / 1000000.0;

            return (x * x + y * y) <= 1.0;
        }
    }
}
