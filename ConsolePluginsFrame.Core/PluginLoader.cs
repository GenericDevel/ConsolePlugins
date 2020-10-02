using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePluginsFrame.Core
{
    public class PluginLoader
    {
        private static PluginLoader instance;

        /// <summary>
        /// Get or Create a instance of the PluginLoader
        /// </summary>
        public static PluginLoader Instance
        {
            get {
                if (instance == null)
                    instance = new PluginLoader();

                return instance;
            }
        }
        /// <summary>
        /// List of Plugins
        /// </summary>
        public List<IPlugin> Plugins { get; set; }

        /// <summary>
        /// The Folder to save the plugins
        /// </summary>
        public string PluginsFolder;

        /// <summary>
        /// Load all plugins dll in the folder
        /// </summary>
        public void LoadPlugins()
        {
            try
            {
                Plugins = new List<IPlugin>();

                if (!PluginsFolder.Contains(@":\"))
                    PluginsFolder = Directory.GetCurrentDirectory()
                        + (PluginsFolder.StartsWith("\\") ? "" : "\\")
                        + PluginsFolder;

                //Load the DLLs from the Plugins directory
                if (Directory.Exists(PluginsFolder))
                {
                    string[] files = Directory.GetFiles(PluginsFolder);
                    foreach (string file in files)
                    {
                        if (file.EndsWith(".dll"))
                        {
                            Assembly.LoadFile(Path.GetFullPath(file));
                        }
                    }
                }

                Type interfaceType = typeof(IPlugin);
                //Fetch all types that implement the interface IPlugin and are a class
                Type[] types = AppDomain.CurrentDomain.GetAssemblies()
                    .SelectMany(a => a.GetTypes())
                    .Where(p => interfaceType.IsAssignableFrom(p) && p.IsClass)
                    .ToArray();
                foreach (Type type in types)
                {
                    //Create a new instance of all found types
                    Plugins.Add((IPlugin)Activator.CreateInstance(type));
                }
            }
            catch (Exception e)
            {
                this.WriteErrorMsg(e.Message);
            }
        }

        public void PluginsRun()
        {
            try
            {
                foreach (IPlugin plugin in Plugins)
                {                   
                    plugin.ReadConfig();
                    plugin.Run();                 
                }
            }
            catch (Exception e)
            {
                this.WriteErrorMsg(e.Message);
            }
        }

        /// <summary>
        /// Write error msg.
        /// </summary>
        /// <param name="msg"></param>
        private void WriteErrorMsg(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.BackgroundColor = ConsoleColor.White;
            Console.WriteLine(string.Format(" Caught exception: {0}", msg));
            Console.ResetColor();
        }
    }
}
