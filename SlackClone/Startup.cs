using HotChocolate;
using HotChocolate.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SlackClone.Models;
using SlackClone.GraphQL;
using Microsoft.AspNetCore.Http;
using SlackClone.GraphQL.Queries;
using SlackClone.GraphQL.Mutations;

namespace SlackClone
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime.
        // Use this method to add services to the container.
        // For more information on how to configure your application,
        // visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            // Adds GraphQL Schema
            services
                .AddDbContext<SlackCloneDbContext>()
                .AddGraphQL(sb =>
                    SchemaBuilder.New()
                        .AddServices(sb)
                        .AddQueryType(d => d.Name("Query"))
                        .AddType<TeamQueries>()
                        .AddMutationType(d => d.Name("Mutation"))
                        .AddType<TeamMutations>()
                        //.AddSubscriptionType(d => d.Name("Subscription"))
                        .Create());
        }

        public class Query
        {
            public string hello => "world";
        }

        // This method gets called by the runtime.
        // Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseWebSockets();

            app.UseHttpsRedirection();

            // Adds GraphQL Service
            app.UseGraphQL();

            // Adds Playground IDE
            app.UsePlayground();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("GraphQL Server Launched");
                });
            });
        }
    }
}
