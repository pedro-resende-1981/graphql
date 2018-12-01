using GraphQL.Types;
using GraphQLpoc.Api.Viewmodels;
using GraphQLPoc.Models;

namespace GraphQLpoc.Api.GraphQL.Types
{
    public class ProductLineType : ObjectGraphType<ProductLineVm>
    {
        public ProductLineType(StoreContext context)
        {
            Field(x => x.Id);
            Field(x => x.OrderId);
            Field(x => x.Price);
            Field(x => x.ProductId);
            Field(x => x.Quantity);
            Field<StringGraphType>("productName", resolve: ctx => ctx.Source.Product.Name);
        }
    }
}
