using GraphQL.Types;
using GraphQLPoc.Models;

namespace GraphQLpoc.Api.GraphQL.Types
{
    public class SupplierType : ObjectGraphType<Supplier>
    {
        public SupplierType()
        {
            Field(x => x.Id);
            Field(x => x.Name);
            Field(x => x.ExternalId, type: typeof(GuidGraphType)).Description("External Id");
            Field<ListGraphType<ProductType>>(name: "Products", resolve: ctx => ctx.Source.Products);
        }
    }
}
