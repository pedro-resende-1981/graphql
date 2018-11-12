using GraphQL.Types;
using GraphQLPoc.Models;

namespace GraphQLpoc.Api.GraphQL.Types
{
    public class OrderType : ObjectGraphType<Order>
    {
        public OrderType()
        {
            Field(x => x.Id);
            Field(x => x.CustomerAddress);
            Field(x => x.CustomerName);
            Field(x => x.ExternalId, type: typeof(GuidGraphType)).Description("External identifier of the Order");
            Field(x => x.OrderDate);
            Field<ListGraphType<ProductLineType>>("productLines", resolve: ctx => ctx.Source.ProductLines, description: "Order Products");
        }
    }
}
