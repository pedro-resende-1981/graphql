using StructureMap;

namespace GraphQLPoc.Api.IoC
{
    public class IocContainer : Container
    {
        public IContainer Container { get; }

        public IocContainer()
        {
            Container = new Container(config =>
            {
                config.AddRegistry<GraphQLRegistry>();
            });
        }
    }
}
