// 代码生成时间: 2025-09-06 09:28:11
using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace JsonFormattingApp
{
    public class JsonDataFormatter
    {
        /// <summary>
        /// Converts JSON data according to specified rules.
        /// </summary>
        /// <param name="jsonData">The input JSON data.</param>
        /// <returns>The formatted JSON data.</returns>
        public string FormatJson(string jsonData)
        {
            try
            {
                JObject jObject = JObject.Parse(jsonData);
                // Perform any necessary conversions here
                // For example, converting all numbers to strings
                foreach (var token in jObject.Descendants())
                {
                    if (token is JValue value && value.Type == JTokenType.Integer || value.Type == JTokenType.Float)
                    {
                        token.Replace(value.ToString());
                    }
                }
                return jObject.ToString(Formatting.Indented);
            }
            catch (JsonReaderException ex)
            {
                Console.WriteLine("Error parsing JSON: " + ex.Message);
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine("An unexpected error occurred: " + ex.Message);
                return null;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            JsonDataFormatter formatter = new JsonDataFormatter();
            string inputJson = "{"name":"John", "age":30}";
            string formattedJson = formatter.FormatJson(inputJson);
            if (formattedJson != null)
            {
                Console.WriteLine("Formatted JSON: 
" + formattedJson);
            }
        }
    }
}
