using System;
using System.Collections.Generic;
using System.Collections.Specialized;
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

        public static NameValueCollection GetAllSetting()
        {
            return ConfigurationManager.AppSettings;
        }

        public static bool AddUpdateAppSettings(string key, string value)
        {
            try
            {
                var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                var settings = configFile.AppSettings.Settings;

                if (settings[key] == null)
                {
                    settings.Add(key, value);
                }
                else
                {
                    settings[key].Value = value;
                }

                configFile.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }
        public static bool BatchAddUpdateAppAddressSettings(Dictionary<string, string> settingsDic)
        {
            try
            {
                var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                var settings = configFile.AppSettings.Settings;

                foreach (var item in settingsDic)
                {
                    var idAddress = item.Key.Split('-')[1];
                    var value = item.Value;
                    var key = settings.AllKeys.FirstOrDefault(x => x.Contains(idAddress));

                    if (settings[key] != null)
                    {
                        settings.Remove(key);
                    }
                    settings.Add(item.Key, value);
                }
                configFile.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }
    }
}
