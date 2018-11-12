using GraphQL.Types;
using GraphQLpoc.Api.Viewmodels;
using GraphQLPoc.Models;

namespace GraphQLpoc.Api.GraphQL.Types
{
    public class ProductType : ObjectGraphType<Product>
    {
        public ProductType()
        {
            Field(x => x.Id);
            Field(x => x.Name, true);
            Field(x => x.Category);
            Field(x => x.Price);
            Field(x => x.ExternalId, type: typeof(GuidGraphType)).Description("External identifier");
            Field<SupplierType>(name: "Supplier", resolve: ctx => ctx.Source.Supplier);
        }
    }
}
