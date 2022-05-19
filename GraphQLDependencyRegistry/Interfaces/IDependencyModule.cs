using HotChocolate.Execution.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GraphQLDependencyRegistry.Interfaces
{
    public interface IDependencyModule
    {
        void ConfigureServices(IServiceCollection services);
        void ConfigureGraphQLTypes(IRequestExecutorBuilder configuration);
    }
}
