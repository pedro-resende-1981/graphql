using System;
using System.Collections.Generic;

namespace GraphQLPoc.Models
{
    public static class DatabaseInitializer
    {
        public static void Initialize(StoreContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            var supplier = new Supplier();
            var products = new List<Product>
            {
                new Product()
                {
                    Name = "Computer A",
                    ExternalId = Guid.NewGuid(),
                    Price = 1000,
                    Category = "IT",
                    Supplier = supplier
                },
                new Product()
                {
                    Name = "Computer B",
                    ExternalId = Guid.NewGuid(),
                    Price = 1500,
                    Category = "IT",
                    Supplier = supplier
                },
                new Product()
                {
                    Name = "Computer C",
                    ExternalId = Guid.NewGuid(),
                    Price = 600,
                    Category = "IT",
                    Supplier = supplier
                },
                new Product()
                {
                    Name = "Smartphone A",
                    ExternalId = Guid.NewGuid(),
                    Price = 1000,
                    Category = "Mobile",
                    Supplier = supplier
                },
                new Product()
                {
                    Name = "Samsung LED TV",
                    ExternalId = Guid.NewGuid(),
                    Price = 2000,
                    Category = "TV",
                    Supplier = supplier
                }
            };

            var orders = new List<Order>
            {
                new Order()
                {
                    CustomerAddress = "Street test 101",
                    CustomerName = "Customer 1",
                    ExternalId = Guid.NewGuid(),
                    Vat = 23m,
                    OrderDate = DateTime.UtcNow,
                    ProductLines = new List<ProductLine>()
                    {
                        new ProductLine()
                        {
                            Price = 500,
                            Product = products[0],
                            Quantity = 1,
                        },
                        new ProductLine()
                        {
                            Price = 700,
                            Product = products[1],
                            Quantity = 1,
                        },
                        new ProductLine()
                        {
                            Price = 1000,
                            Product = products[2],
                            Quantity = 1,
                        }
                    }
                },
                new Order()
                {
                    CustomerAddress = "Street test 101",
                    CustomerName = "Customer 2",
                    ExternalId = Guid.NewGuid(),
                    Vat = 23m,
                    OrderDate = DateTime.UtcNow,
                    ProductLines = new List<ProductLine>()
                    {
                        new ProductLine()
                        {
                            Price = 1200,
                            Product = products[3],
                            Quantity = 1,
                        },
                        new ProductLine()
                        {
                            Price = 2000,
                            Product = products[4],
                            Quantity = 1,
                        }
                    }
                }
            };

            context.Products.AddRange(products);
            context.Orders.AddRange(orders);
            context.SaveChanges();
        }
    }
}
