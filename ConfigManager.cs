using SerializerLib;
using System.IO;

namespace ConfigManagerLib
{
    public class ConfigManager<T> : IConfigManager<T> where T : new()
    {
        private ISerializer _serializer;

        public ConfigManager(string configPath)
        {
            _serializer = new XMLSerializer();
            ConfigPath = configPath;
            try
            {
                Config = _serializer.Deserialize<T>(File.ReadAllText(ConfigPath));
            }
            catch
            {
                Config = new T();
            }
        }

        /// <summary>
        /// Config object readed from a file
        /// </summary>
        public T Config { get; private set; }

        /// <summary>
        /// Config file path 
        /// </summary>
        public string ConfigPath { get; private set; }

        /// <summary>
        /// Save the current config object in the ConfigPath file
        /// </summary>
        public void Save()
        {
            if (!Directory.Exists(Path.GetDirectoryName(ConfigPath)))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(ConfigPath));
            }
            File.WriteAllText(ConfigPath, _serializer.Serialize(Config));
        }
    }
}
