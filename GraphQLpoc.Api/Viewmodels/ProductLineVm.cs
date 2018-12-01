namespace GraphQLpoc.Api.Viewmodels
{
    public class ProductLineVm
    {
        public int ProductId { get; set; }

        public ProductVm Product { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }

        public int OrderId { get; set; }
    }
}