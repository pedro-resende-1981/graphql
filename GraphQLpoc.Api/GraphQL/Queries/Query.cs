using GraphQL.Types;

namespace GraphQLPoc.Api.GraphQL.Queries
{
    public class Query : ObjectGraphType
    {
        public Query()
        {
            Name = "Query";
            Field<ProductQueries>("productsapi", resolve: context => new { });
            Field<OrderQueries>("ordersapi", resolve: context => new { });
            Field<SupplierQueries>("suppliersapi", resolve: context => new { });
        }
    }
}
