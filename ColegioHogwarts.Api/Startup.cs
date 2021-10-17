using ColegioHogwarts.Core.Interfaces;
using ColegioHogwarts.Core.Services;
using ColegioHogwarts.Infraestructure.Data;
using ColegioHogwarts.Infraestructure.Filters;
using ColegioHogwarts.Infraestructure.Repositories;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace ColegioHogwarts.Api
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
            services.AddControllers();

            //Inyeccion de dependencia para la Base De Datos
            services.AddDbContext<ColegioHogwartsDBContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("ColegioHogwarts"))
            );

            //Inyeccion de dependencias
            services.AddTransient<ICandidateRepository, CandidateRepository>();
            services.AddTransient<ICandidateService, CandidateService>();
            services.AddTransient<IHouseRepository, HouseRepository>();

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddMvc(options => {
                options.Filters.Add<ValidationFilter>();
            }).AddFluentValidation(options => {
                options.RegisterValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());  
            });

            services.AddControllers(options =>
            {
                options.Filters.Add<GlobalExceptionFilter>();
            });

            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
