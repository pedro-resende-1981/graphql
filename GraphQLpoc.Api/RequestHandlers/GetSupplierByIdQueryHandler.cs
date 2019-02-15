using System;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading;
using System.Threading.Tasks;
using GraphQLPoc.Api.Extensions;
using GraphQLPoc.Api.Requests.Queries;
using GraphQLPoc.Models;
using MediatR;

namespace GraphQLPoc.Api.RequestHandlers
{
    public class GetSupplierByIdQueryHandler : IRequestHandler<GetSupplierByIdQuery, Supplier>
    {

        private readonly StoreContext _context;

        public GetSupplierByIdQueryHandler(StoreContext context)
        {
            _context = context;
        }

        public Task<Supplier> Handle(GetSupplierByIdQuery request, CancellationToken cancellationToken)
        {
            var argument = request.GraphQLContext.GetArgument<string>("externalId");
            var selectedPropertiesList = request.GraphQLContext.GetSelectedPropertiesListAsString();
            var result = _context
                .Suppliers
                .Select<Supplier>($"new(id,{selectedPropertiesList})")
                .SingleOrDefault(p => p.ExternalId == Guid.Parse(argument));

            return Task.FromResult(result);
        }
    }
}