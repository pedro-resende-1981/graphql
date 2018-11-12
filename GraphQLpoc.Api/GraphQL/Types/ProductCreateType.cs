using GraphQL.Types;

namespace GraphQLpoc.Api.GraphQL.Types
{
    public class ProductCreateType : InputObjectGraphType
    {
        public ProductCreateType()
        {
            Name = "ProductCreate";
            Field<NonNullGraphType<StringGraphType>>("name");
            Field<NonNullGraphType<StringGraphType>>("category");
            Field<NonNullGraphType<DecimalGraphType>>("price");
        }
    }
}
