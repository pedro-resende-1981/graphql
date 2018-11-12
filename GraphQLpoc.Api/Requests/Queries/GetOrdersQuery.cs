using System.Linq;
using GraphQL.Types;
using GraphQLPoc.Models;
using MediatR;

namespace GraphQLPoc.Api.Requests.Queries
{
    public class GetOrdersQuery : IRequest<IQueryable<Order>>
    {
        public ResolveFieldContext<object> GraphQLContext { get; }

        public GetOrdersQuery(ResolveFieldContext<object> context)
        {
            GraphQLContext = context;
        }
    }
}
