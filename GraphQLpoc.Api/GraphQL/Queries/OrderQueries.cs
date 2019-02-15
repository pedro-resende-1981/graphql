using System.Collections.Generic;
using AutoMapper;
using GraphQL.Types;
using GraphQLpoc.Api.GraphQL.Types;
using GraphQLpoc.Api.Viewmodels;
using GraphQLPoc.Api.Requests.Queries;
using MediatR;

namespace GraphQLPoc.Api.GraphQL.Queries
{
    public class OrderQueries : ObjectGraphType
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public OrderQueries(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;

            FieldAsync<OrderType>(
                "order",
                arguments: new QueryArguments(new QueryArgument<StringGraphType> { Name = "externalId" }),
                resolve: async ctx =>
                {
                    var result = await _mediator.Send(new GetOrderByIdQuery(ctx));
                    return _mapper.Map<OrderVm>(result);
                });

            FieldAsync<ListGraphType<OrderType>>(
                "orders",
                resolve: async ctx =>
                {
                    var result = await _mediator.Send(new GetOrdersQuery(ctx));
                    return _mapper.Map<List<OrderVm>>(result);
                });
        }
    }
}
