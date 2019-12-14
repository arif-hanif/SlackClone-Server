using HotChocolate;
using HotChocolate.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MongoDB.Driver;
using SlackClone.Models;
using SlackClone.GraphQL;
using HotChocolate.Utilities;
using MongoDB.Bson;

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
            // setup type conversion for object id
            TypeConversion.Default.Register<string, ObjectId>(ObjectId.Parse);
            TypeConversion.Default.Register<ObjectId, string>(from => from.ToString());


            services.AddSingleton<IMongoClient>(s =>
                new MongoClient(
                    Configuration.GetConnectionString("MongoDb")));

            services.AddScoped(s =>
                new SlackCloneDbContext(
                    s.GetRequiredService<IMongoClient>(), Configuration["DatabaseName"]));

            // Adds GraphQL Schema
            services.AddGraphQL(services =>
                SchemaBuilder.New()
                    .AddServices(services)
                    .AddQueryType<QueryType>()
                    .AddMutationType<MutationType>()
                    .Create());

            services.AddTypeConverter<string, ObjectId>(ObjectId.Parse);

            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/build";
            });
        }

        // This method gets called by the runtime.
        // Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSpaStaticFiles();

            // Adds GraphQL Service
            app.UseGraphQL();
            // Adds Playground IDE
            app.UsePlayground();

            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseReactDevelopmentServer(npmScript: "start");
                }
            });
        }
    }
}
