using GraphQL.Types;
using GraphQLPoc.Models;
using MediatR;

namespace GraphQLPoc.Api.Requests.Queries
{
    public class GetProductByIdQuery : IRequest<Product>
    {
        public ResolveFieldContext<object> GraphQLContext { get; }

        public GetProductByIdQuery(ResolveFieldContext<object> context)
        {
            GraphQLContext = context;
        }
    }
}
