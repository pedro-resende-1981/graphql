using GraphQL.Types;
using GraphQLPoc.Models;
using MediatR;

namespace GraphQLPoc.Api.Requests.Queries
{
    public class GetSupplierByIdQuery : IRequest<Supplier>
    {
        public ResolveFieldContext<object> GraphQLContext { get; }

        public GetSupplierByIdQuery(ResolveFieldContext<object> context)
        {
            GraphQLContext = context;
        }
    }
}
