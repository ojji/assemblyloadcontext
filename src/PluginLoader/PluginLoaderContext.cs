using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.Loader;

namespace PluginLoader
{
    public class PluginLoaderContext : AssemblyLoadContext
    {
        private readonly AssemblyDependencyResolver _assemblyDependencyResolver;
        private readonly HashSet<string> _defaultLoadedAssemblies = new HashSet<string>();

        public PluginLoaderContext(string pluginPath, ICollection<AssemblyName> sharedAssemblies)
        {
            _assemblyDependencyResolver = new AssemblyDependencyResolver(pluginPath);
            foreach (var sharedAssembly in sharedAssemblies)
            {
                AddToDefaultLoadedAssemblies(sharedAssembly);
            }
        }

        private void AddToDefaultLoadedAssemblies(AssemblyName sharedAssembly)
        {
            if (_defaultLoadedAssemblies.Contains(sharedAssembly.Name))
            {
                return;
            }

            _defaultLoadedAssemblies.Add(sharedAssembly.Name);

            var assembly = AssemblyLoadContext.Default.LoadFromAssemblyName(sharedAssembly);
            foreach (var referencedAssembly in assembly.GetReferencedAssemblies())
            {
                AddToDefaultLoadedAssemblies(referencedAssembly);
            }
        }

        protected override Assembly Load(AssemblyName assemblyName)
        {
            if (_defaultLoadedAssemblies.Contains(assemblyName.Name))
            {
                if (Default.LoadFromAssemblyName(assemblyName) != null)
                {
                    return null;
                }
            }

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
