namespace ConfigManagerLib
{
    public interface IConfigManager<T>
    {
        /// <summary>
        /// Config object readed from a file
        /// </summary>
        T Config { get; }

        /// <summary>
        /// Config file path 
        /// </summary>
        string ConfigPath { get; }

        /// <summary>
        /// Save the current config object in the ConfigPath file
        /// </summary>
        void Save();
    }
}
