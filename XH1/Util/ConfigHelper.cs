using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XH1.Util
{
    public class ConfigHelper
    {
        public static string GetConfiguaration(string name)
        {
            return ConfigurationManager.AppSettings[name];
        }
    }
}
