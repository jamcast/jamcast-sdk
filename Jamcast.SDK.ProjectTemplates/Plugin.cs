using System;
$if$ ($targetframeworkversion$ >= 3.5)using System.Linq;
$endif$using Jamcast.Extensibility;
using $safeprojectname$.Renderers;

namespace $safeprojectname$
{
    public class Plugin : SimplePlugin
    {
        public override Type RootObjectRendererType
        {
            get { return typeof(RootRenderer); }
        }        

        public override bool Startup()
        {
            PluginDataProvider.OnPluginDataChanged += PluginDataProvider_OnPluginDataChanged;         
            return true;
        }

        private void PluginDataProvider_OnPluginDataChanged(string key)
        {
            if (key.Equals(Configuration.CONFIGURATION_KEY))
            {
                Configuration.Refresh();
                // handle any configuration changes here
            }
        }
    }
}