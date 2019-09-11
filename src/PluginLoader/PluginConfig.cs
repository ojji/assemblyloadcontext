using System.Collections.Generic;
using System.Reflection;

namespace PluginLoader
{
    public class PluginConfig
    {
        public PluginConfig(string pluginPath)
        {
            PluginPath = pluginPath;
        }

        public string PluginPath { get; }
        public ICollection<AssemblyName> SharedAssemblies { get; } = new List<AssemblyName>();
    }
}