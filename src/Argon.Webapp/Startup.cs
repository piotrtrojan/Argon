using Argon.Webapp.Contexts;
using Argon.Webapp.Repositories;
using Argon.Webapp.Utils;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace Argon.Webapp
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
            
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "Argon API",
                    Description = "Example of CQRS",
                    TermsOfService = "None",
                    Contact = new Contact() { Name = "Piotr Trojan", Email = "kontakt@piotrtrojan.com", Url = "www.piotrtrojan.com" }
                });
                c.IncludeXmlComments(GetXmlCommentsPath());
                c.DescribeAllEnumsAsStrings();
            });
            var queryConnectionString = Configuration["QueryConnectionString"];
            var commandConnectionString = Configuration["CommandConnectionString"];
            services.AddSingleton(new QueryConnectionStringWrapper(queryConnectionString));
            services.AddSingleton(new CommandConnectionStringWrapper(commandConnectionString));
            services.AddEntityFrameworkSqlServer()
               .AddDbContext<ArgonDbContext>();
            RegisterRepositories(services);
            services.AddDecorators();
            services.AddSingleton<Messages>();
            RegisterMapper();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ArgonDbContext argonDbContext)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Argon API");
            });

            argonDbContext.Database.EnsureCreated();
        }

        private void RegisterRepositories(IServiceCollection services)
        {
            services.AddTransient<StudentRepository>();
        }

        private void RegisterMapper()
        {
        }

        private string GetXmlCommentsPath()
        {
            var app = System.AppContext.BaseDirectory;
            return System.IO.Path.Combine(app, "Argon.Webapp.xml");
        }
    }
}