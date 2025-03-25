using GuideAPI.Services;
using GuideAPI.Services.Interface;

namespace GuideAPI.Config
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services)
        {

            services.AddScoped(typeof(Repositories.IDepartment<>), typeof(Repositories.Department<>));
            services.AddScoped<IDepartmentService, Department>();

            return services;
        }
    }
}
