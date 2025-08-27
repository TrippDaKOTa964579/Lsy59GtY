// 代码生成时间: 2025-08-27 22:40:17
using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace TextFileAnalysis
{
    /// <summary>
    /// Text file content analyzer.
    /// </summary>
    public class TextFileAnalyzer
    {
        /// <summary>
        /// Analyzes a text file and extracts statistics.
        /// </summary>
        /// <param name="filePath">Path to the text file.</param>
        /// <returns>A dictionary containing statistics about the file content.</returns>
        public static Dictionary<string, object> Analyze(string filePath)
        {
            var statistics = new Dictionary<string, object>();
            try
            {
                // Check if the file exists
                if (!File.Exists(filePath))
                {
                    throw new FileNotFoundException("File not found.", filePath);
                }

                // Read file content
                string content = File.ReadAllText(filePath);

                // Characters count
                statistics.Add("TotalCharacters", content.Length);

                // Lines count
                statistics.Add("TotalLines", content.Split(new[] { "
" }, StringSplitOptions.None).Length);

                // Words count
                statistics.Add("TotalWords", Regex.Matches(content, @"\b[\w']+\").Count);

                // Unique words count
                HashSet<string> uniqueWords = new HashSet<string>(
                    Regex.Matches(content, @"\b[\w']+\").Cast<Match>().Select(m => m.Value)
                );
                statistics.Add("UniqueWords", uniqueWords.Count);

                // Most common words
                var mostCommonWords = new Dictionary<string, int>();
                foreach (Match match in Regex.Matches(content, @"\b[\w']+\"))
                {
                    string word = match.Value;
                    if (!mostCommonWords.ContainsKey(word))
                    {
                        mostCommonWords[word] = 1;
                    }
                    else
                    {
                        mostCommonWords[word]++;
                    }
                }
                var maxWord = mostCommonWords.Aggregate(
                    mostCommonWords.KeyValuePairs,
                    (max, pair) => max.Value > pair.Value ? max : pair
                );
                statistics.Add("MostCommonWord", maxWord.Key);
                statistics.Add("FrequencyOfMostCommonWord", maxWord.Value);

                return statistics;
            }
            catch (Exception ex)
            {
                // Handle exceptions and return error message
                Console.WriteLine($"An error occurred: {ex.Message}");
                return null;
            }
        }
    }
}
