using Blog.API.Managers;
using Blog.API.Repositories.Interfaces;
using Blog.API.Repositories;
using Blog.API.Providers;
using Blog.API.Context;
using Microsoft.EntityFrameworkCore;

namespace Blog.API.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddCustomServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddJwtConfiguration(configuration);
            services.AddScoped<JwtTokenManager>();
           
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IPostRepository,IPostRepository>();

            services.AddScoped<UserProvider>();
            services.AddHttpContextAccessor();
        }

        public static void MigrateIdentityDb(this WebApplication app)
        {
            if (app.Services.GetService<AppDbContext>() != null)
            {
                var identityDb = app.Services.GetRequiredService<AppDbContext>();
                identityDb.Database.Migrate();
            }
        }

    }
}
