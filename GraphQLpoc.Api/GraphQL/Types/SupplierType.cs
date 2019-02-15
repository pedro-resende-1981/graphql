using GraphQL.Types;
using GraphQLpoc.Api.Viewmodels;

namespace GraphQLpoc.Api.GraphQL.Types
{
    public class SupplierType : ObjectGraphType<SupplierVm>
    {
        public SupplierType()
        {
            Field(x => x.Name);
            Field(x => x.ExternalId, type: typeof(GuidGraphType)).Description("External identifier");
            Field<ListGraphType<ProductType>>(name: "Products", resolve: ctx => ctx.Source.Products);
        }
    }
}
