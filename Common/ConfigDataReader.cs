using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace  Common
{
    public static class ConfigDataReader
    {

        public static int GetConfigIntValue(string key)
        {
            if(string.IsNullOrEmpty(key))
            {
                return 0;
            }
            int result = 0;
           if(! Int32.TryParse(ConfigurationManager.AppSettings[key],out result))
            {
                return 0;
            }

                return result;
        }
    }
}
