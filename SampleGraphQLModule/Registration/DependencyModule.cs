using GraphQLDependencyRegistry.Interfaces;
using HotChocolate.Execution.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SampleGraphQLModule.Interfaces;
using SampleGraphQLModule.Services;

namespace SampleGraphQLModule.Registration
{
    internal class DependencyModule : IDependencyModule
    {
        public void ConfigureGraphQLTypes(IRequestExecutorBuilder configuration)
        {
            configuration
                .AddTypeExtension<SampleQuery>()
                .AddTypeExtension<SampleMutation>();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddScoped<ISampleService, SampleService>();
        }
    }
}
