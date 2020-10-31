using GraphQL;
using GraphQL.Execution;
using GraphQL.Instrumentation;
using GraphQL.Server.Ui.GraphiQL;
using GraphQL.SystemTextJson;
using GraphQL.Types;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using VSSUMMIT.Demo.GraphQL.Settings;
using VSSUMMIT.Demo00.ExternalAPI;
using VSSUMMIT.Demo00.Repository;

namespace VSSUMMIT.Demo00
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IDocumentExecuter, DocumentExecuter>();
            services.AddSingleton<IDocumentWriter, DocumentWriter>();

            // add options configuration
            services.Configure<GraphQLSettings>(Configuration);

            // add Field Middlewares
            services.AddScoped<InstrumentFieldsMiddleware>();

            // add graph types
            services.AddScoped<ExampleQuery>();
            services.AddScoped<ExampleMutation>();
            services.AddScoped<UserType>();
            services.AddScoped<PostType>();
            services.AddScoped<FollowersType>();
            services.AddScoped<UserInputType>();
            services.AddScoped<GitHubBranchType>(); // External API

            // add schema
            services.AddScoped<ISchema, ExampleSchema>();

            //DB Context
            services.AddScoped<DemoContext>();
            services.AddDbContextPool<DemoContext>(options => options.UseSqlServer(
                Configuration.GetConnectionString("DemoDbConnection"))
            );

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<UserRepository>();
            services.AddScoped<PostRepository>();
            services.AddScoped<FollowerRepository>();

            services.AddScoped<GitHubApi>();
            services.AddHttpClient();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseMiddleware<GraphQLMiddleware>();
            app.UseGraphiQLServer(new GraphiQLOptions());
        }
    }
}
