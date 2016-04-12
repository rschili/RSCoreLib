using System;
using System.Configuration;

namespace RSCoreLib
    {
    public static class AppSettings
        {
        public static bool? GetBooleanSetting(string key)
            {
            string value = ConfigurationManager.AppSettings[key];
            if (string.IsNullOrEmpty(value))
                return null;

            bool result;
            if (bool.TryParse(value, out result))
                return result;

            return null;
            }

        public static string[] GetStringArraySetting (string key, char separator = ';')
            {
            string value = ConfigurationManager.AppSettings[key];
            if (string.IsNullOrEmpty(value))
                return null;

            return value.Split(separator);
            }
        }
    }
