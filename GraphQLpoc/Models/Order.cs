using System;
using System.Collections.Generic;

namespace GraphQLPoc.Models
{
    public class Order
    {
        public Order()
        {
            ExternalId = Guid.NewGuid();
            OrderDate = DateTime.UtcNow;
        }

        public int Id { get; set; }

        public Guid ExternalId { get; set; }

        public DateTime OrderDate { get; set; }

        public string CustomerName { get; set; }

        public string CustomerAddress { get; set; }

        public virtual ICollection<ProductLine> ProductLines { get; set; }

        public decimal Vat { get; set; }
    }
}
