using System;
using System.Collections.Generic;

namespace GraphQLpoc.Api.Viewmodels
{
    public class SupplierVm
    {
        public Guid ExternalId { get; set; }

        public string Name { get; set; }

        public virtual IEnumerable<ProductVm> Products { get; set; }
    }
}
