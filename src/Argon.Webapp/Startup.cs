using Argon.Webapp.CommandHandlers;
using Argon.Webapp.CommandHandlers.Student;
using Argon.Webapp.Commands.Student;
using Argon.Webapp.Contexts;
using Argon.Webapp.Dtos.Student;
using Argon.Webapp.Models;
using Argon.Webapp.Queries.Student;
using Argon.Webapp.QueryHandlers;
using Argon.Webapp.QueryHandlers.Student;
using Argon.Webapp.Repositories;
using Argon.Webapp.Utils;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using System.Collections.Generic;

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
            services.AddEntityFrameworkSqlServer()
               .AddDbContext<ArgonDbContext>();

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

            RegisterRepositories(services);
            RegisterHandlers(services);
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

        private void RegisterHandlers(IServiceCollection services)
        {
            // Commands
            services.AddTransient<ICommandHandler<RegisterStudentCommand>, RegisterStudentCommandHandler>();
            services.AddTransient<ICommandHandler<UpdateStudentInfoCommand>, UpdateStudentInfoCommanHandler>();

            //Queries
            services.AddTransient<IQueryHandler<GetStudentByIdQuery, StudentResponseDto>, GetStudentByIdQueryHandler>();
            services.AddTransient<IQueryHandler<GetStudentListQuery, ICollection<StudentResponseDto>>, GetStudentListQueryHandler>();
        }

        private void RegisterMapper()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Student, StudentResponseDto>();
            });
        }
        private string GetXmlCommentsPath()
        {
            var app = System.AppContext.BaseDirectory;
            return System.IO.Path.Combine(app, "Argon.Webapp.xml");
        }

    }
}
