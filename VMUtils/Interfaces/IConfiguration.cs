namespace VMUtils.Interfaces
{
    public interface IConfiguration
    {
        /// <summary>
        /// Gets an App setting from a configuration file from the calling assembly
        /// </summary>
        /// <param name="key">name of configuration key</param>
        /// <returns>config value</returns>
        string ReadSetting(string key);

        /// <summary>
        /// Gets and app setting from a configuration file than converts it to a boolean
        /// </summary>
        /// <param name="key">name of configuration key</param>
        /// <returns>a boolean version of the config value</returns>
        bool ReadBooleanSetting(string key);

        /// <summary>
        /// Adds or updates configuration setting
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        void AddUpdateAppSettings(string key, string value);


    }
}
