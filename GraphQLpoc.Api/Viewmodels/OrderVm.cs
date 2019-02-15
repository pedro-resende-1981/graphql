using System;
using System.Collections.Generic;

namespace GraphQLpoc.Api.Viewmodels
{
    public class OrderVm
    {
        public Guid ExternalId { get; set; }

        public DateTime OrderDate { get; set; }

        public string CustomerName { get; set; }

        public string CustomerAddress { get; set; }

        public virtual ICollection<ProductLineVm> ProductLines { get; set; }

        public decimal Vat { get; set; }
    }
}
