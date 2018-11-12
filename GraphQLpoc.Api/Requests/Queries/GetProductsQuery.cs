using System.Linq;
using GraphQL.Types;
using GraphQLPoc.Models;
using MediatR;

namespace GraphQLPoc.Api.Requests.Queries
{
    public class GetProductsQuery : IRequest<IQueryable<Product>>
    {
        public ResolveFieldContext<object> GraphQLContext { get; }

        public GetProductsQuery(ResolveFieldContext<object> context)
        {
            GraphQLContext = context;
        }
    }
}
