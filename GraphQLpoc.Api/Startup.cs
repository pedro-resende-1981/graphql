using GraphiQl;
using GraphQLPoc.Api.IoC;
using GraphQLPoc.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StructureMap;


namespace GraphQLPoc.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            
            services.AddDbContext<StoreContext>(options =>
                options
                    .UseSqlServer(Configuration.GetConnectionString("GraphQLPocDb"))
                    .UseLazyLoadingProxies());
        }

        public void ConfigureContainer(Registry registry)
        {
            registry.IncludeRegistry<GraphQLRegistry>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, StoreContext ctx)
        {
            // DatabaseInitializer.Initialize(ctx);

            app.UseGraphiQl();
            app.UseMvc();
        }
    }
}
