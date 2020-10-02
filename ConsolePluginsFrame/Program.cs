using ConsolePluginsFrame.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePluginsFrame
{
    class Program
    {
        static void Main(string[] args)
        {
            PluginLoader.Instance.PluginsFolder = "Plugins";
            Console.WriteLine("Started plugin app..");
            try
            {
                PluginLoader.Instance.LoadPlugins();
                PluginLoader.Instance.PluginsRun();
                Console.ReadKey();
            }
            catch (Exception e)
            {
                Console.WriteLine(string.Format("Plugins couldn't be loaded: {0}", e.Message));
                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
                Environment.Exit(0);
            }

        }
    }
}
