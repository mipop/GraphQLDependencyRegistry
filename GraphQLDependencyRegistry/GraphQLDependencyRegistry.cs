using GraphQLDependencyRegistry.Interfaces;
using HotChocolate.Execution.Configuration;
using Microsoft.Extensions.DependencyModel;
using System.Reflection;
using System.Text.RegularExpressions;

namespace GraphQLDependencyRegistry
{
    public static class GraphQLRuntimeRegistry
    {
        /// <summary>
        /// Uses reflection to register GraphQL types and services from assemblies implementing <see cref="IDependencyModule"/>.
        /// </summary>
        /// <param name="configuration">The GraphQL configuration builder</param>
        /// <param name="assemblyNamesPattern">RegEx pattern matching the assembly names that will be searched for implementations of <see cref="IDependencyModule"/>.</param>
        /// <returns>The <see cref="IRequestExecutorBuilder"/> so that configuration can be chained.</returns>
        public static IRequestExecutorBuilder AddGraphQLAssemblyTypes(this IRequestExecutorBuilder configuration, string assemblyNamesPattern)
        {
            var regex = new Regex(assemblyNamesPattern, RegexOptions.IgnoreCase);
            var matchingAssemblies = DependencyContext.Default.RuntimeLibraries
                .Where(a => regex.IsMatch(a.Name))
                .Select(a => Assembly.Load(a.Name));

            var dependencyModuleTypes = matchingAssemblies
                .SelectMany(a => a.GetTypes())
                .Where(t => t.GetInterface(nameof(IDependencyModule)) != null);

            foreach (var moduleType in dependencyModuleTypes)
            {
                if (Activator.CreateInstance(moduleType) is IDependencyModule module)
                {
                    module.ConfigureGraphQLTypes(configuration);
                    module.ConfigureServices(configuration.Services);
                }
            }

            return configuration;
        }
    }
}