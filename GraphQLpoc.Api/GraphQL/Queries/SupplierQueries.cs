using AutoMapper;
using GraphQL.Types;
using GraphQLpoc.Api.GraphQL.Types;
using GraphQLpoc.Api.Viewmodels;
using GraphQLPoc.Api.Requests.Queries;
using MediatR;
using System.Collections.Generic;

namespace GraphQLPoc.Api.GraphQL.Queries
{
    public class SupplierQueries : ObjectGraphType
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public SupplierQueries(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;

            FieldAsync<SupplierType>(
                "supplier",
                arguments: new QueryArguments(new QueryArgument<StringGraphType> {Name = "externalId"}),
                resolve: async ctx =>
                {
                    var result = await _mediator.Send(new GetSupplierByIdQuery(ctx));
                    return _mapper.Map<SupplierVm>(result);
                });

            FieldAsync<ListGraphType<SupplierType>>(
                "suppliers",
                resolve: async ctx =>
                {
                    var result = await _mediator.Send(new GetSuppliersQuery(ctx));
                    return _mapper.Map<List<SupplierVm>>(result);
                });
        }
    }
}

