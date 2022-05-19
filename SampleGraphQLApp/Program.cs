using GraphQLDependencyRegistry;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddGraphQLServer()
    .AddQueryType(d => d.Name("Query"))
    .AddMutationType(d => d.Name("Mutation"))
    .AddGraphQLAssemblyTypes("SampleGraphQLModule")
    .AddMutationConventions(applyToAllMutations: true);

var app = builder.Build();

app.MapGraphQL();

app.Run();

