////////////////////////////////////////////
/// File    : IPlug.cs
/// Desc    : The Plugin Interface
/// Author  : Li G.Q.
/// Date    : 2020/10/1
////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePluginsFrame.Core
{
    /// <summary>
    /// The interface for plugins library
    /// </summary>
    public interface IPlugin
    {
        /// <summary>
        /// The plugin name
        /// </summary>
        string Name { get; }

        /// <summary>
        /// The plugin description
        /// </summary>
        string Desc { get; }

        /// <summary>
        /// The entrance of this plugin
        /// </summary>
        /// <param name="parameters"></param>
        void Run();

        /// <summary>
        /// Read some settings from app.config in the main application.
        /// </summary>
        void ReadConfig();
    }
}
