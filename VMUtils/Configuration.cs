using System;
using System.Configuration;

namespace VMUtils
{
    public class Configuration : IConfiguration
    {
        /// <summary>
        /// Gets an App setting from a configuration file from the calling assembly
        /// </summary>
        /// <param name="key">name of configuration key</param>
        /// <returns>config value</returns>
        public string ReadSetting(string key)
        {
            try
            {
                var appSettings = ConfigurationManager.AppSettings;
                return appSettings[key] ?? "";
                
            }
            catch (ConfigurationErrorsException)
            {
                return "ERROR";
            }
        }

        public void AddUpdateAppSettings(string key, string value)
        {
            //This functionality is not needed and is used for a placeholder
            throw new NotImplementedException();
        }
    }
}