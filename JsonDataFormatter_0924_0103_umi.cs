// 代码生成时间: 2025-09-24 01:03:48
 * The code is structured for maintainability and extensibility.
 */

using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.IO;

namespace JsonDataFormatterApp
{
    public class JsonDataFormatter
    {
        // Converts a JSON string to a specified object type.
        public T ConvertJsonToObject<T>(string jsonString) where T : class
        {
            try
            {
                // Deserialize the JSON string into an object of type T.
                return JsonSerializer.Deserialize<T>(jsonString);
            }
            catch (JsonException ex)
            {
                // Handle JSON deserialization exceptions.
                Console.WriteLine($"Error deserializing JSON: {ex.Message}");
                return null;
            }
        }

        // Converts an object to a JSON string.
        public string ConvertObjectToJson(object obj)
        {
            try
            {
                // Serialize the object into a JSON string.
                return JsonSerializer.Serialize(obj);
            }
            catch (JsonException ex)
            {
                // Handle JSON serialization exceptions.
                Console.WriteLine($"Error serializing object to JSON: {ex.Message}");
                return null;
            }
        }
    }

    // Main class to run the JsonDataFormatter example.
    public class Program
    {
        public static void Main(string[] args)
        {
            JsonDataFormatter formatter = new JsonDataFormatter();

            // Example object to convert.
            var person = new
            {
                Name = "John Doe",
                Age = 30
            };

            // Convert object to JSON string.
            string json = formatter.ConvertObjectToJson(person);
            Console.WriteLine($"Object to JSON: {json}");

            // Convert JSON back to object.
            dynamic convertedPerson = formatter.ConvertJsonToObject<dynamic>(json);
            Console.WriteLine($"JSON to Object: {convertedPerson.Name}, {convertedPerson.Age}");
        }
    }
}
