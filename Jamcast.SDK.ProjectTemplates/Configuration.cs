using System;
$if$ ($targetframeworkversion$ >= 3.5)using System.Linq;
$endif$using Jamcast.Extensibility;

namespace $safeprojectname$
{
    public class Configuration
    {
        private static Configuration _instance;
        internal const string CONFIGURATION_KEY = "$safeprojectname$";
        
        public string SomeStringValue { get; set; }

        private Configuration()
        {
        }

        internal static Configuration Instance
        {
            get
            {
                if (_instance == null)
                {
                    Refresh();
                }

                return _instance;
            }
        }

        internal static void Refresh()
        {
            _instance = PluginDataProvider.XmlDeserialize<Configuration>(CONFIGURATION_KEY);

            if (_instance == null)
            {
                _instance = new Configuration();                
                _instance.Save();
            }
        }

        internal void Save()
        {
            PluginDataProvider.XmlSerialize<Configuration>(CONFIGURATION_KEY, _instance);
        }
    }
}