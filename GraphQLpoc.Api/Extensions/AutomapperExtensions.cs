﻿using AutoMapper;
using GraphQLpoc.Api.Viewmodels;
using GraphQLPoc.Models;

namespace GraphQLPoc.Api.Extensions
{
    public static class AutomapperExtensions
    {
        public static IMapperConfigurationExpression WithGraphQLApiMappings(this IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<Product, ProductVm>();
            configuration.CreateMap<Supplier, SupplierVm>();

            return configuration;
        }
    }
}
