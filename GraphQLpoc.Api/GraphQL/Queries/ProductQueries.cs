using GraphQL.Types;
using GraphQLpoc.Api.GraphQL.Types;
using GraphQLPoc.Api.Requests.Queries;
using MediatR;

namespace GraphQLPoc.Api.GraphQL.Queries
{
    public class ProductQueries : ObjectGraphType
    {
        private readonly IMediator _mediator;

        public ProductQueries(IMediator mediator)
        {
            _mediator = mediator;

            Field<ProductType>(
                "product",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> {Name = "id"}),
                resolve: ctx =>
                {
                    var result = _mediator.Send(new GetProductByIdQuery(ctx));
                    return result;
                });

            Field<ListGraphType<ProductType>>(
                "products",
                resolve: ctx =>
                {
                    var result = _mediator.Send(new GetProductsQuery(ctx));
                    return result;
                });
        }
    }
}
