using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VMUtils
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
        /// Adds or updates configuration setting
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        void AddUpdateAppSettings(string key, string value);


    }
}
