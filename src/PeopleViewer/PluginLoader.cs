using System;
using System.Reflection;
using System.Runtime.Loader;

namespace PeopleViewer
{
    public class PluginLoader : AssemblyLoadContext
    {
        private readonly AssemblyDependencyResolver _assemblyDependencyResolver;
        public PluginLoader(string pluginPath)
        {
            _assemblyDependencyResolver = new AssemblyDependencyResolver(pluginPath);
        }

        protected override Assembly Load(AssemblyName assemblyName)
        {
            var assemblyPath = _assemblyDependencyResolver.ResolveAssemblyToPath(assemblyName);
            if (assemblyPath != null)
            {
                return LoadFromAssemblyPath(assemblyPath);
            }

            return base.Load(assemblyName);
        }

        protected override IntPtr LoadUnmanagedDll(string unmanagedDllName)
        {
            var assemblyPath = _assemblyDependencyResolver.ResolveUnmanagedDllToPath(unmanagedDllName);
            if (assemblyPath != null)
            {
                return LoadUnmanagedDllFromPath(assemblyPath);
            }

            return base.LoadUnmanagedDll(unmanagedDllName);
        }
    }
}