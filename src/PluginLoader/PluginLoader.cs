using System;
using System.Reflection;

namespace PluginLoader
{
    public class PluginLoader
    {
        public static PluginLoader CreateLoader(string pluginPath, Type[] sharedTypes)
        {
            return CreateLoader(pluginPath, config =>
            {
                if (sharedTypes != null && sharedTypes.Length != 0)
                {
                    foreach (var sharedType in sharedTypes)
                    {
                        config.SharedAssemblies.Add(sharedType.Assembly.GetName());
                    }
                }
            });
        }

        private static PluginLoader CreateLoader(string pluginPath, Action<PluginConfig> configurate)
        {
            var config = new PluginConfig(pluginPath);
            configurate(config);
            return new PluginLoader(config);
        }

        private readonly PluginConfig _config;
        private readonly PluginLoaderContext _context;

        private PluginLoader(PluginConfig config)
        {
            _config = config;
            _context = CreateLoaderContext(_config);
        }

        private PluginLoaderContext CreateLoaderContext(PluginConfig config)
        {
            return new PluginLoaderContext(config.PluginPath, config.SharedAssemblies);
        }

        public Assembly LoadPlugin()
        {
            return _context.LoadFromAssemblyPath(_config.PluginPath);
        }
    }
}