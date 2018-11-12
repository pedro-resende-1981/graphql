using GraphQL.Types;
using GraphQLpoc.Api.GraphQL.Types;
using GraphQLPoc.Api.Requests.Queries;
using MediatR;

namespace GraphQLPoc.Api.GraphQL.Queries
{
    public class SupplierQueries : ObjectGraphType
    {
        private readonly IMediator _mediator;

        public SupplierQueries(IMediator mediator)
        {
            _mediator = mediator;

            Field<SupplierType>(
                "supplier",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> {Name = "id"}),
                resolve: ctx =>
                {
                    var result = _mediator.Send(new GetSupplierByIdQuery(ctx));
                    return result;
                });

            Field<ListGraphType<SupplierType>>(
                "suppliers",
                resolve: ctx =>
                {
                    var result = _mediator.Send(new GetSuppliersQuery(ctx));
                    return result;
                });
        }
    }
}
