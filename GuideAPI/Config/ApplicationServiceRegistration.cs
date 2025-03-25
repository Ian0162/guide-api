using System.Reflection;

namespace GuideAPI.Config
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(
            this IServiceCollection services)
        {

            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            return services;
        }
    }
}
