namespace Themepark.API
{
    public static class GraphQLServiceCollectionExtensions
    {
        public static IServiceCollection AddGraphQLConfiguration(this IServiceCollection services)
        {
            // Queries and mutations are automatically registered through this
            var assembly = typeof(Program).Assembly;
            var queriesAndMutations = GetQueriesAndMutations(assembly);
            // var graphQLConfig = configuration.GetSection("GraphQL").Get<GraphQLConfig>();

            services
                .AddGraphQLServer()
                .AddQueryType()
                //.AddMutationType()
                .AddTypes(queriesAndMutations)
                .AddApolloTracing()
                .AddType(() => new UuidType("Uuid"));

            return services;
        }

        private static System.Type[] GetQueriesAndMutations(System.Reflection.Assembly assembly) =>
            assembly.GetTypes().Where(x => x.GetCustomAttributes(typeof(ExtendObjectTypeAttribute), false).Length > 0).ToArray();
    }
}
