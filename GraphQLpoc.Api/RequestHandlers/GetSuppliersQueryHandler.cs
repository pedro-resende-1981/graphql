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
    public class GetSuppliersQueryHandler : IRequestHandler<GetSuppliersQuery, IQueryable<Supplier>>
    {

        private readonly StoreContext _context;

        public GetSuppliersQueryHandler(StoreContext context)
        {
            _context = context;
        }

        public Task<IQueryable<Supplier>> Handle(GetSuppliersQuery request, CancellationToken cancellationToken)
        {
            var selectedPropertiesList = request.GraphQLContext.GetSelectedPropertiesListAsString();
            var results = _context
                .Suppliers
                .Select<Supplier>($"new({selectedPropertiesList})");

            return Task.FromResult(results);
        }
    }
}
