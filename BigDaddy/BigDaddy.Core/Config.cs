using System;
using System.Configuration;
using System.Globalization;
using System.Reflection;

namespace BigDaddy.Core
{
    public static class Config
    {
        private static readonly UriBuilder uri = new UriBuilder(Assembly.GetExecutingAssembly().CodeBase);

        private static readonly Configuration config = ConfigurationManager.OpenExeConfiguration(uri.Path);

        private static readonly KeyValueConfigurationCollection AppSettings = config.AppSettings.Settings;

        private static readonly NumberFormatInfo formatInfo = new NumberFormatInfo()
        {
            NumberGroupSeparator = "",
            CurrencyDecimalSeparator = "."
        };

        public static T Get<T>(string name)
        {
            return (T)Convert.ChangeType(AppSettings[name].Value, typeof(T), formatInfo);
        }
    }
}
