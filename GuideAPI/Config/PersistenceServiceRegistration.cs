using GuideAPI.Repositories;
using GuideAPI.Repositories.Interface;
using GuideAPI.Services;
using GuideAPI.Services.Interface;

namespace GuideAPI.Config
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services)
        {

            services.AddScoped(typeof(IDepartment<>), typeof(Repositories.Department<>));
            services.AddScoped<IAuthentication,Authentication>();
            services.AddScoped<IDepartmentService, Department>();
            services.AddScoped<IAuthService, AuthService>();


            return services;
        }
    }
}
    