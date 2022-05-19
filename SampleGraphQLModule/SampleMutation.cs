using HotChocolate;
using HotChocolate.Types;
using SampleGraphQLModule.Interfaces;

namespace SampleGraphQLModule
{
    [ExtendObjectType("Mutation")]
    public class SampleMutation
    {
        public string ChangeHello([Service] ISampleService service, string hello)
        {
            return service.ChangeHello(hello);
        }
    }
}
