// 代码生成时间: 2025-09-22 21:56:40
// JsonDataFormatter.cs
using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace JsonDataFormatter
{
    /// <summary>
    /// A utility class for converting JSON data into different formats.
    /// </summary>
    public static class JsonDataFormatter
    {
        /// <summary>
        /// Converts JSON string to an object of type T.
        /// </summary>
        /// <typeparam name="T">The type of object to convert to.</typeparam>
        /// <param name="json">The JSON string to convert.</param>
        /// <returns>The converted object of type T.</returns>
        public static T ConvertFromJson<T>(string json)
        {
            if (string.IsNullOrEmpty(json))
            {
                throw new ArgumentException("JSON string is null or empty.", nameof(json));
            }

            try
            {
                return JsonConvert.DeserializeObject<T>(json);
            }
            catch (JsonException ex)
            {
                throw new InvalidOperationException("Failed to deserialize the JSON string.", ex);
            }
        }

        /// <summary>
        /// Converts an object of type T to a JSON string.
        /// </summary>
        /// <typeparam name="T">The type of object to convert.</typeparam>
        /// <param name="obj">The object to convert.</param>
        /// <returns>The JSON string representation of the object.</returns>
        public static string ConvertToJson<T>(T obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(nameof(obj), "Object to convert is null.");
            }

            try
            {
                return JsonConvert.SerializeObject(obj);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Failed to serialize the object to JSON.", ex);
            }
        }
    }
}