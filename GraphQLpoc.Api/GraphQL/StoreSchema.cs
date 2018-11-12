using GraphQL;
using GraphQL.Types;
using GraphQLPoc.Api.GraphQL.Mutations;
using GraphQLPoc.Api.GraphQL.Queries;

namespace GraphQLPoc.Api.GraphQL
{
    public class StoreSchema : Schema
    {
        public StoreSchema(IDependencyResolver resolver) :  base(resolver)
        {
            Query = resolver.Resolve<Query>();
            Mutation = resolver.Resolve<CreateProductMutation>();
        }
    }
}
