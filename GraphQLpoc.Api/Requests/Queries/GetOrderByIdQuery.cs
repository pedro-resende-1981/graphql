using System.Linq;
using GraphQL.Types;
using GraphQLPoc.Models;
using MediatR;

namespace GraphQLPoc.Api.Requests.Queries
{
    public class GetOrderByIdQuery : IRequest<Order>
    {
        public ResolveFieldContext<object> GraphQLContext { get; }

        public GetOrderByIdQuery(ResolveFieldContext<object> context)
        {
            GraphQLContext = context;
        }
    }
}
