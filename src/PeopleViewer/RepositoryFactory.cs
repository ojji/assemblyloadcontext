using System;
using System.Collections.Specialized;
using System.Configuration;
using System.Linq;
using System.Reflection;
using PeopleRepository.Interface;

namespace PeopleViewer
{
    public class RepositoryFactory
    {
        public static IPeopleRepository CreateRepository()
        {
            var repositorySettings = ConfigurationManager.GetSection("RepositorySettings") as NameValueCollection;
            if (repositorySettings == null)
            {
                throw new ConfigurationErrorsException("Could not find the repository settings configuration in the App.config file.");
            }
            
            string typeName = repositorySettings["RepositoryTypeName"];
            string pluginPath = repositorySettings["PluginPath"];
            string repositoryTypeParam = repositorySettings["RepositoryTypeParam"];

            string typeNameWithoutAssembly = typeName.Split(',', StringSplitOptions.RemoveEmptyEntries).ToArray()[0].Trim();
            string assemblyName = typeName.Split(',', StringSplitOptions.RemoveEmptyEntries).ToArray()[1].Trim();

            var pluginLoader = new PluginLoader(pluginPath);
            var assembly = pluginLoader.LoadFromAssemblyName(new AssemblyName(assemblyName));
            
            var type = assembly.GetType(typeNameWithoutAssembly, true);

            IPeopleRepository repository = null;
            if (repositoryTypeParam != null)
            {
                return Activator.CreateInstance(type, new object[] {repositoryTypeParam}) as IPeopleRepository;
            }
            else
            {
                return Activator.CreateInstance(type, new object[] {}) as IPeopleRepository;
            }
        }
    }
}