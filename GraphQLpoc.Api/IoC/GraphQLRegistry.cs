using AutoMapper;
using GraphQL;
using GraphQL.Types;
using GraphQLpoc.Api.GraphQL.Types;
using GraphQLPoc.Api.Extensions;
using GraphQLPoc.Api.GraphQL;
using GraphQLPoc.Api.GraphQL.Mutations;
using GraphQLPoc.Api.GraphQL.Queries;
using MediatR;
using StructureMap;

namespace GraphQLPoc.Api.IoC
{
    public class GraphQLRegistry : Registry
    {
        public GraphQLRegistry()
        {
            For<IMapper>()
                .Use(nameof(Mapper), context => new MapperConfiguration(c => c.WithGraphQLApiMappings()).CreateMapper())
                .ContainerScoped();

            For<IDocumentExecuter>().Use<DocumentExecuter>();

            For<ProductQueries>().Singleton();
            For<CreateProductMutation>().Singleton();
            For<ProductType>().Singleton();
            For<ProductCreateType>().Singleton();
            For<ProductLineType>().Singleton();
            For<SupplierType>().Singleton();
            For<OrderType>().Singleton();

            For<ISchema>().Use(ctx => new StoreSchema(new FuncDependencyResolver(type => ctx.GetInstance(type))));

            RegisterMediatR();
        }

        private void RegisterMediatR()
        {
            Scan(scanner =>
            {
                scanner.AssemblyContainingType<Startup>(); // Our assembly with requests & handlers
                scanner.AddAllTypesOf(typeof(IRequestHandler<>));
                scanner.AddAllTypesOf(typeof(IRequestHandler<,>));
                scanner.AddAllTypesOf(typeof(IPipelineBehavior<,>));
            });

            For<ServiceFactory>().Use<ServiceFactory>(ctx => ctx.GetInstance);

            For<IMediator>().Use<Mediator>();
        }
    }
}