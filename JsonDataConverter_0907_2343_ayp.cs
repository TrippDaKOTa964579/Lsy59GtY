// 代码生成时间: 2025-09-07 23:43:11
 * Requirements:
 * - Clear code structure for easy understanding.
 * - Proper error handling.
 * - Adequate comments and documentation.
 * - Follow C# best practices.
 * - Ensure code maintainability and scalability.
 */

using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.IO;

namespace JsonDataConverter
{
    public class JsonDataConverter
    {
        // Function to convert JSON data
        public string ConvertJson(string inputJson, string outputPath)
        {
            try
            {
                // Deserialize JSON string to JObject
                JObject jsonData = JsonConvert.DeserializeObject(inputJson) as JObject;

                // Check if deserialization is successful
                if (jsonData == null)
                {
                    throw new JsonException("Deserialization failed. Input is not valid JSON.");
                }

                // Serialize JObject back to JSON string
                string outputJson = jsonData.ToString(Formatting.Indented);

                // Write output JSON to file
                File.WriteAllText(outputPath, outputJson);

                return "Conversion successful. Output saved to: " + outputPath;
            }
            catch (JsonException je)
            {
                // Handle JSON-specific errors
                return $"Error: {je.Message}";
            }
            catch (Exception ex)
            {
                // Handle other exceptions
                return $"Unexpected error: {ex.Message}";
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Example usage of JsonDataConverter
            var converter = new JsonDataConverter();
            string inputJson = "{"name": "John", "age": 30}";
            string outputPath = "output.json";

            string result = converter.ConvertJson(inputJson, outputPath);
            Console.WriteLine(result);
        }
    }
}
