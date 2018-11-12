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
    public class GetOrdersQueryHandler : IRequestHandler<GetOrdersQuery, IQueryable<Order>>
    {

        private readonly StoreContext _context;

        public GetOrdersQueryHandler(StoreContext context)
        {
            _context = context;
        }

        public Task<IQueryable<Order>> Handle(GetOrdersQuery request, CancellationToken cancellationToken)
        {
            var selectedPropertiesList = request.GraphQLContext.GetSelectedPropertiesListAsString();
            var results = _context
                .Orders
                .Select<Order>($"new({selectedPropertiesList})");

            return Task.FromResult(results);
        }
    }
}
