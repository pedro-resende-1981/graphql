using System;
using System.Collections.Generic;

namespace GraphQLPoc.Models
{
    public class Supplier
    {
        public int Id { get; private set; }

        public Guid ExternalId { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Product> Products { get; set; }

        public Supplier()
        {
            ExternalId = Guid.NewGuid();
        }
    }
}