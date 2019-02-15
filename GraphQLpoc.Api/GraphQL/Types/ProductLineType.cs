using GraphQL.Types;
using GraphQLpoc.Api.Viewmodels;

namespace GraphQLpoc.Api.GraphQL.Types
{
    public class ProductLineType : ObjectGraphType<ProductLineVm>
    {
        public ProductLineType()
        {
            Field(x => x.Price);
            Field<StringGraphType>("productExternalId", resolve: ctx => ctx.Source.Product.ExternalId);
            Field(x => x.Quantity);
            Field<StringGraphType>("productName", resolve: ctx => ctx.Source.Product.Name);
        }
    }
}
