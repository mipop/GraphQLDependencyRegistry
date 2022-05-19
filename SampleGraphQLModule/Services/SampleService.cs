using SampleGraphQLModule.Interfaces;

namespace SampleGraphQLModule.Services
{
    internal class SampleService : ISampleService
    {
        private string _hello = "Hello World";
        public string ChangeHello(string hello)
        {
            _hello = hello;
            return _hello;
        }

        public string SayHello()
        {
            return _hello;
        }
    }
}
