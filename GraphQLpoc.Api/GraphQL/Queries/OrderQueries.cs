using GraphQL.Types;
using GraphQLpoc.Api.GraphQL.Types;
using GraphQLPoc.Api.Requests.Queries;
using MediatR;

namespace GraphQLPoc.Api.GraphQL.Queries
{
    public class OrderQueries : ObjectGraphType
    {
        private readonly IMediator _mediator;

        public OrderQueries(IMediator mediator)
        {
            _mediator = mediator;

            Field<OrderType>(
                "order",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "id" }),
                resolve: ctx =>
                {
                    var result = _mediator.Send(new GetOrderByIdQuery(ctx));
                    return result;
                });

            Field<ListGraphType<OrderType>>(
                "orders",
                resolve: ctx =>
                {
                    var result = _mediator.Send(new GetOrdersQuery(ctx));
                    return result;
                });
        }
    }
}
