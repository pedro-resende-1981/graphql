using System.Linq;
using GraphQL.Types;
using GraphQLPoc.Models;
using MediatR;

namespace GraphQLPoc.Api.Requests.Queries
{
    public class GetSuppliersQuery : IRequest<IQueryable<Supplier>>
    {
        public ResolveFieldContext<object> GraphQLContext { get; }

        public GetSuppliersQuery(ResolveFieldContext<object> context)
        {
            GraphQLContext = context;
        }
    }
}
