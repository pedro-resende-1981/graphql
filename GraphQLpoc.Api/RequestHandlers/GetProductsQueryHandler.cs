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
    public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, IQueryable<Product>>
    {

        private readonly StoreContext _context;

        public GetProductsQueryHandler(StoreContext context)
        {
            _context = context;
        }

        public Task<IQueryable<Product>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            var selectedPropertiesList = request.GraphQLContext.GetSelectedPropertiesListAsString();
            var results = _context
                .Products
                .Select<Product>($"new({selectedPropertiesList})");

            return Task.FromResult(results);
        }
    }
}
