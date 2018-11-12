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
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, Product>
    {

        private readonly StoreContext _context;

        public GetProductByIdQueryHandler(StoreContext context)
        {
            _context = context;
        }

        public Task<Product> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var argument = request.GraphQLContext.GetArgument<int>("id");
            var selectedPropertiesList = request.GraphQLContext.GetSelectedPropertiesListAsString();
            var result = _context
                .Products
                .Select<Product>($"new(id,{selectedPropertiesList})")
                .SingleOrDefault(p => p.Id == argument);

            return Task.FromResult(result);
        }
    }
}
