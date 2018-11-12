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
    public class GetOrderByIdQueryHandler : IRequestHandler<GetOrderByIdQuery, Order>
    {

        private readonly StoreContext _context;

        public GetOrderByIdQueryHandler(StoreContext context)
        {
            _context = context;
        }

        public Task<Order> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
        {
            var argument = request.GraphQLContext.GetArgument<int>("id");
            var selectedPropertiesList = request.GraphQLContext.GetSelectedPropertiesListAsString();
            var result = _context
                .Orders
                .Select<Order>($"new(id,{selectedPropertiesList})")
                .SingleOrDefault(p => p.Id == argument);

            return Task.FromResult(result);
        }
    }
}
