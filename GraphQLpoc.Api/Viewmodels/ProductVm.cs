using System;

namespace GraphQLpoc.Api.Viewmodels
{
    public class ProductVm
    {
        public Guid ExternalId { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Category { get; set; }

        public virtual SupplierVm Supplier { get; set; }
    }
}
