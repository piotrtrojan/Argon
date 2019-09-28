using System;
using Argon.Webapp.CommandHandlers;
using Argon.Webapp.CommandHandlers.Student;
using Argon.Webapp.Commands.Student;
using Argon.Webapp.Dtos.Student;
using Argon.Webapp.Models;
using Argon.Webapp.Repositories;
using Argon.Webapp.Utils;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

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

            RegisterRepositories(services);
            RegisterHandlers(services);
            services.AddSingleton<Messages>();
            RegisterMapper();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }

        private void RegisterRepositories(IServiceCollection services)
        {
            services.AddTransient<StudentRepository>();

        }

        private void RegisterHandlers(IServiceCollection services)
        {
            services.AddTransient<ICommandHandler<RegisterStudentCommand>, RegisterStudentCommandHandler>();
        }

        private void RegisterMapper()
        {
            Mapper.CreateMap<Student, StudentResponseDto>(); // TODO: Finish this bullshit.
        }

    }
}
