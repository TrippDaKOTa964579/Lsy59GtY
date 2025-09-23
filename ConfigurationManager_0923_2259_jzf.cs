// 代码生成时间: 2025-09-23 22:59:21
using System;
using System.Configuration;
using System.IO;

namespace ConfigurationManagerApp
{
    public class ConfigurationManager
    {
        // 配置文件路径
        private readonly string configFilePath;

        // 构造函数，初始化配置文件路径
        public ConfigurationManager(string configFilePath)
        {
            if (string.IsNullOrEmpty(configFilePath))
                throw new ArgumentException("配置文件路径不能为空", nameof(configFilePath));

            this.configFilePath = configFilePath;
        }

        // 读取配置文件中的值
        public string ReadAppSetting(string key)
        {
            try
            {
                ExeConfigurationFileMap configFileMap = new ExeConfigurationFileMap() { ExeConfigFilename = configFilePath };
                Configuration config = ConfigurationManager.OpenMappedExeConfiguration(configFileMap, ConfigurationUserLevel.None);
                var appSettings = config.AppSettings.Settings;

                if (appSettings[key] == null)
                    throw new KeyNotFoundException($"未找到键为'{key}'的设置");

                return appSettings[key].Value;
            }
            catch (Exception ex)
            {
                // 处理读取配置文件时的错误
                throw new InvalidOperationException($"读取配置文件失败：{ex.Message}", ex);
            }
        }

        // 写入配置文件中的值
        public void WriteAppSetting(string key, string value)
        {
            try
            {
                ExeConfigurationFileMap configFileMap = new ExeConfigurationFileMap() { ExeConfigFilename = configFilePath };
                Configuration config = ConfigurationManager.OpenMappedExeConfiguration(configFileMap, ConfigurationUserLevel.None);
                var appSettings = config.AppSettings.Settings;

                if (appSettings[key] == null)
                {
                    appSettings.Add(key, value);
                }
                else
                {
                    appSettings[key].Value = value;
                }

                config.Save(ConfigurationSaveMode.Modified);
            }
            catch (Exception ex)
            {
                // 处理写入配置文件时的错误
                throw new InvalidOperationException($"写入配置文件失败：{ex.Message}", ex);
            }
        }
    }
}
