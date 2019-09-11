# AssemblyLoadContext usage sample

This sample project shows how to use the .NET Core `System.Runtime.Loader.AssemblyLoadContext` class in conjunction with the new .NET Core 3.0 class `System.Runtime.Loader.AssemblyDependencyResolver`

# Overview
The sample project `PeopleViewer` gets data from a plugin loaded at runtime. The plugins implement the interface `IPeopleRepository` from the common referenced project `PeopleRepository.Interface` and the configuration is done in the `App.config` file.
There are 3 sample repository projects
- `PeopleRepository.Csv` gets it's data from a CSV file
- `PeopleRepository.Service` uses a gRpc service to populate it's data
- `PeopleRepository.Sql` connects to a Sql server to get it's data

The configuration is read and the plugin is instantiated by the Service locator `RepositoryFactory` in the UI viewmodel.

# The plugin loading scenario
To load a plugin we have to create a `PluginLoader` class through the ``PluginLoader.CreateLoader(string pluginPath, Type[] sharedTypes)``
static method, where the plugin path should be an absolute path to the component dll, and the sharedTypes collection should include the common implemented interface. Those types in the shared collection are loaded through the `AssemblyLoadContext.Default` default assembly load context and thus when the plugins are trying to resolve their interface assembly, the type definitions will be the same as in the calling context. After the loader is instantiated, call the `LoadPlugin()` to get the assembly and use whatever reflection magic you need to get the plugin implemented types.

Example: 
```csharp
// Load the csv repository plugin implementing the IPeopleRepository common interface
var pluginLoader = PluginLoader.CreateLoader(
                      @"d:\Sample\plugins\PeopleRepository.Csv.dll", 
                      new[] {typeof(IPeopleRepository)});
var assembly = pluginLoader.LoadPlugin();

// Get the type definition and instantiate a CsvRepository object
var type = assembly.GetType("PeopleRepository.Csv.CsvRepository", true);
return Activator.CreateInstance(type, new object[] {}) as IPeopleRepository;
```
