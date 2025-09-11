// 代码生成时间: 2025-09-11 09:09:50
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using System.Text.Json.Serialization;
using System.Text.Json;

// 定义一个用于配置文件管理的类
public class ConfigFileManager<T> where T : new()
{
    // 配置文件路径
    private readonly string _configFilePath;

    // 构造函数，初始化配置文件路径
    public ConfigFileManager(string configFilePath)
    {
        _configFilePath = configFilePath;
    }

    // 加载配置文件
    public T LoadConfig()
    {
        try
        {
            if (!File.Exists(_configFilePath))
            {
                throw new FileNotFoundException("配置文件未找到。");
            }

            // 使用JsonSerializer读取配置文件
            var config = JsonSerializer.Deserialize<T>(File.ReadAllText(_configFilePath));
            return config;
        }
        catch (FileNotFoundException ex)
        {
            Console.WriteLine(ex.Message);
            return new T(); // 返回默认实例
        }
        catch (JsonException ex)
        {
            Console.WriteLine($"解析配置文件失败：{ex.Message}");
            return new T(); // 返回默认实例
        }
        catch (Exception ex)
        {
            Console.WriteLine($"加载配置文件时发生错误：{ex.Message}");
            return new T(); // 返回默认实例
        }
    }

    // 保存配置文件
    public void SaveConfig(T config)
    {
        try
        {
            // 使用JsonSerializerOptions确保输出的Json格式更加清晰
            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };

            // 将配置对象序列化为Json字符串并保存到文件
            File.WriteAllText(_configFilePath, JsonSerializer.Serialize(config, options));
        }
        catch (Exception ex)
        {
            Console.WriteLine($"保存配置文件时发生错误：{ex.Message}");
        }
    }
}

// 定义一个简单的配置类作为示例
public class AppConfig
{
    [JsonPropertyName("databaseUrl")]
    public string DatabaseUrl { get; set; }

    [JsonPropertyName("apiKey")]
    public string ApiKey { get; set; }
}

// 示例代码，展示如何使用ConfigFileManager类
public class Program
{
    public static void Main()
    {
        var configManager = new ConfigFileManager<AppConfig>("appConfig.json");

        // 加载配置
        var config = configManager.LoadConfig();
        Console.WriteLine($"数据库URL: {config.DatabaseUrl}");
        Console.WriteLine($"API密钥: {config.ApiKey}");

        // 修改配置
        config.DatabaseUrl = "https://new-database-url.com";
        config.ApiKey = "new-api-key";

        // 保存配置
        configManager.SaveConfig(config);
    }
}