using System;
using GraphQL.Types;
using GraphQLpoc.Api.GraphQL.Types;
using GraphQLPoc.Models;

namespace GraphQLPoc.Api.GraphQL.Mutations
{
    public class CreateProductMutation : ObjectGraphType
    {
        private readonly StoreContext _context;

        public CreateProductMutation(StoreContext context)
        {
            _context = context;

            Name = "CreateProductMutation";
            Field<ProductType>(
                "createProduct",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<ProductCreateType>> {Name = "product"}
                ),
                resolve: ctx =>
                {
                    var product = ctx.GetArgument<Product>("product");
                    product.ExternalId = Guid.NewGuid();
                    _context.Products.Add(product);
                    _context.SaveChanges();

                    return product;
                });
        }
    }
}
