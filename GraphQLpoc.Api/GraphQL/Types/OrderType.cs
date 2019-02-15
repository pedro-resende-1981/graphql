using GraphQL.Types;
using GraphQLpoc.Api.Viewmodels;

namespace GraphQLpoc.Api.GraphQL.Types
{
    public class OrderType : ObjectGraphType<OrderVm>
    {
        public OrderType()
        {
            Field(x => x.ExternalId, type: typeof(GuidGraphType)).Description("External identifier of the Order");
            Field(x => x.CustomerAddress);
            Field(x => x.CustomerName);
            Field(x => x.OrderDate);
            Field<ListGraphType<ProductLineType>>("productLines", resolve: ctx => ctx.Source.ProductLines, description: "Order Products");
        }
    }
}
