using GraphQL.Types;
using GraphQLpoc.Api.Viewmodels;

namespace GraphQLpoc.Api.GraphQL.Types
{
    public class ProductType : ObjectGraphType<ProductVm>
    {
        public ProductType()
        {
            Field(x => x.Name, true);
            Field(x => x.Category);
            Field(x => x.Price);
            Field(x => x.ExternalId, type: typeof(GuidGraphType)).Description("External identifier");
            Field<SupplierType>(name: "Supplier", resolve: ctx => ctx.Source.Supplier);
        }
    }
}
