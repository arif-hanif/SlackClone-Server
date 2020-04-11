using System;
using HotChocolate;
using HotChocolate.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Npgsql;
using SlackClone.GraphQL;
using SlackClone.GraphQL.Mutations;
using SlackClone.GraphQL.Queries;
using SlackClone.Models;

namespace SlackClone {
    public class Startup {
        public IConfiguration Configuration { get; }

        public Startup (IConfiguration configuration) {
            Configuration = configuration;
        }

        // This method gets called by the runtime.
        // Use this method to add services to the container.
        // For more information on how to configure your application,
        // visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices (IServiceCollection services) {

            var databaseUrl = Configuration["DATABASE_URL"];
            var databaseUri = new Uri (databaseUrl);
            var userInfo = databaseUri.UserInfo.Split (':');

            var builder = new NpgsqlConnectionStringBuilder {
                Host = databaseUri.Host,
                Port = databaseUri.Port,
                Username = userInfo[0],
                Password = userInfo[1],
                Database = databaseUri.LocalPath.TrimStart ('/'),
                SslMode = Npgsql.SslMode.Prefer,
                TrustServerCertificate = true
            };

            // Adds GraphQL Schema
            services
                .AddEntityFrameworkNpgsql ()
                .AddDbContext<SlackCloneDbContext> ((sp, opt) =>
                    opt.UseNpgsql (builder.ToString ())
                    .UseInternalServiceProvider (sp))
                .AddGraphQL (sp =>
                    SchemaBuilder.New ()
                    .AddServices (sp)
                    .AddQueryType (d => d.Name ("Query"))
                    .AddType<TeamQueries> ()
                    .AddMutationType (d => d.Name ("Mutation"))
                    .AddType<TeamMutations> ()
                    //.AddSubscriptionType(d => d.Name("Subscription"))
                    .Create ());
        }

        // This method gets called by the runtime.
        // Use this method to configure the HTTP request pipeline.
        public void Configure (IApplicationBuilder app, IWebHostEnvironment env) {
            if (env.IsDevelopment ()) {
                app.UseDeveloperExceptionPage ();
            }

            app.UseRouting ();
            app.UseWebSockets ();
            app.UseHttpsRedirection ();

            // Adds GraphQL Service
            app.UseGraphQL ();

            // Adds Playground IDE
            app.UsePlayground ();

            app.UseEndpoints (endpoints => {
                endpoints.MapGet ("/", async context => {
                    await context.Response.WriteAsync ("GraphQL Server Launched");
                });
            });
        }
    }
}