using HotChocolate;
using HotChocolate.Types;
using SampleGraphQLModule.Interfaces;

namespace SampleGraphQLModule
{
    [ExtendObjectType("Query")]
    public class SampleQuery
    {
        public string SayHello([Service] ISampleService service)
        {
            return service.SayHello();
        }
    }
}