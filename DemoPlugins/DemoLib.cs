using ConsolePluginsFrame.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoPlugins
{
    public class DemoLib: IPlugin
    {
        public void Run()
        {
            foreach (IPlugin plugin in PluginLoader.Instance.Plugins)
            {
                Console.WriteLine("{0}: {1}", plugin.Name, plugin.Desc);
            }
        }


        public void ReadConfig()
        {
            return;
        }

        public string Name
        {
            get
            {
                return "Demo";
            }
        }

        public string Desc
        {
            get
            {
                return "This plugin shows all loaded plugins and their explanations";
            }
        }
    }
}
