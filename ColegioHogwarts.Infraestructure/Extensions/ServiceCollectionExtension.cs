using ColegioHogwarts.Core.Interfaces;
using ColegioHogwarts.Core.Services;
using ColegioHogwarts.Infraestructure.Data;
using ColegioHogwarts.Infraestructure.Options;
using ColegioHogwarts.Infraestructure.Repositories;
using ColegioHogwarts.Infraestructure.Services;
using ColegioHogwarts.Infraestructure.Validators;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace ColegioHogwarts.Infraestructure.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddDbContexts(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ColegioHogwartsDBContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("ColegioHogwarts"))
            );

            return services;
        }

        public static IServiceCollection AddOptions(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<PasswordOptions>(configuration.GetSection("PasswordOptions"));

            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<ICandidateService, CandidateService>();
            services.AddTransient<ISecurityService, SecurityService>();
            services.AddTransient<IHouseValidator, HouseValidator>();
            services.AddSingleton<IPasswordService, PasswordService>();
            services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}




