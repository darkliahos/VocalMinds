using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using VMUtils.Interfaces;

namespace VMUtils
{
    public class AppConfiguration : IConfiguration
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

        /// <summary>
        /// Gets and app setting from a configuration file than converts it to a boolean
        /// </summary>
        /// <param name="key">name of configuration key</param>
        /// <returns>a boolean version of the config value</returns>
        public bool ReadBooleanSetting(string key)
        {
            bool result;
            if (bool.TryParse(ReadSetting(key), out result))
            {
                return result;
            }
            else
            {
                throw new FormatException(string.Format("Unable to Convert Boolean Value {0} for key {1}",result, key));
            }
        }

        public List<string> ReadStringListSettings(string key, char delimiter)
        {
            var splitString = ReadSetting(key).Split(delimiter);
            return splitString.ToList();
        }

        public void AddUpdateAppSettings(string key, string value)
        {
            //This functionality is not needed and is used for a placeholder
            throw new NotImplementedException();
        }
    }
}