using AutoMapper;
using GraphQL.Types;
using GraphQLpoc.Api.GraphQL.Types;
using GraphQLpoc.Api.Viewmodels;
using GraphQLPoc.Api.Requests.Queries;
using MediatR;
using System.Collections.Generic;

namespace GraphQLPoc.Api.GraphQL.Queries
{
    public class ProductQueries : ObjectGraphType
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public ProductQueries(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;

            FieldAsync<ProductType>(
                "product",
                arguments: new QueryArguments(new QueryArgument<StringGraphType> { Name = "externalId" }),
                resolve: async ctx =>
                {
                    var result = await _mediator.Send(new GetProductByIdQuery(ctx));
                    return _mapper.Map<ProductVm>(result);
                });

            FieldAsync<ListGraphType<ProductType>>(
                "products",
                resolve: async ctx =>
                {
                    var result = await _mediator.Send(new GetProductsQuery(ctx));
                    return _mapper.Map<List<ProductVm>>(result); ;
                });
        }
    }
}
