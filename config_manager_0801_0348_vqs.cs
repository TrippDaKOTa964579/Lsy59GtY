// 代码生成时间: 2025-08-01 03:48:30
using System;
using System.IO;
using System.Collections.Generic;
using System.Configuration;

// 配置文件管理器类
public class ConfigManager
{
    // 配置文件路径
    private string configFilePath;

    // 构造函数
    public ConfigManager(string filePath)
    {
        if (string.IsNullOrEmpty(filePath))
        {
            throw new ArgumentException("配置文件路径不能为空", nameof(filePath));
        }

        this.configFilePath = filePath;
    }

    // 加载配置文件
    public Dictionary<string, string> LoadConfig()
    {
        try
        {
            // 检查文件是否存在
            if (!File.Exists(configFilePath))
            {
                throw new FileNotFoundException("配置文件未找到", configFilePath);
            }

            // 读取配置文件
            Configuration config = ConfigurationManager.OpenExeConfiguration(configFilePath);
            Dictionary<string, string> configDictionary = new Dictionary<string, string>();

            foreach (string key in config.AppSettings.Settings.AllKeys)
            {
                configDictionary.Add(key, config.AppSettings.Settings[key].Value);
            }

            return configDictionary;
        }
        catch (Exception ex)
        {
            // 处理异常
            Console.WriteLine($"加载配置文件出错: {ex.Message}");
            throw;
        }
    }

    // 保存配置文件
    public void SaveConfig(Dictionary<string, string> configData)
    {
        try
        {
            // 检查文件是否存在
            if (!File.Exists(configFilePath))
            {
                throw new FileNotFoundException("配置文件未找到", configFilePath);
            }

            // 读取配置文件
            Configuration config = ConfigurationManager.OpenExeConfiguration(configFilePath);

            // 更新配置信息
            foreach (KeyValuePair<string, string> pair in configData)
            {
                config.AppSettings.Settings[pair.Key] = pair.Value;
            }

            // 保存配置文件
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection(configFilePath, "appSettings");
        }
        catch (Exception ex)
        {
            // 处理异常
            Console.WriteLine($"保存配置文件出错: {ex.Message}");
            throw;
        }
    }
}
