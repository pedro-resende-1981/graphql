using GraphQL.Types;
using GraphQLPoc.Models;

namespace GraphQLpoc.Api.GraphQL.Types
{
    public class ProductLineType : ObjectGraphType<ProductLine>
    {
        public ProductLineType(StoreContext context)
        {
            Field(x => x.Id);
            Field(x => x.OrderId);
            Field(x => x.Price);
            Field(x => x.ProductId);
            Field(x => x.Quantity);
            Field<StringGraphType>("productName", resolve: ctx => ctx.Source.Product.Name);
            /*{
                var productName = _context
                    .Products
                    .Where(p => p.Id == ctx.Source.ProductId)
                    .Select(x => x.Name).SingleOrDefault();

                return productName;
            });*/
        }
    }
}
