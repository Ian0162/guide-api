using Microsoft.EntityFrameworkCore;

namespace GuideAPI.Data
{
    public static class Provider
    {
        public static IServiceCollection InitializeDatabase(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<DBContext>(options =>
                options.UseSqlServer(config.GetConnectionString("GuideAPIConnectionStrings")).LogTo(Console.WriteLine, LogLevel.Information)
                .EnableSensitiveDataLogging()
                .EnableDetailedErrors());

            return services;
        }
    }
}
