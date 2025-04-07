using GuideAPI.Repositories.Interface;
using GuideAPI.Repositories;
using GuideAPI.Dto;
using GuideAPI.Filters;
using MediatR;
using GuideAPI.Handler;
using Microsoft.AspNetCore.Identity;
using GuideAPI.Data.Config;
using GuideAPI.Data;

namespace GuideAPI.Config
{
    public static class IdentityServiceRegistration
    {
        public static IServiceCollection AddIdentityServices(this IServiceCollection services)
        {
           services.AddIdentity<ApplicationUser, IdentityRole>()
            .AddRoles<IdentityRole>()
            .AddTokenProvider<DataProtectorTokenProvider<ApplicationUser>>("GuideAPI")
            .AddEntityFrameworkStores<DBContext>()
            .AddDefaultTokenProviders();

            return services;
        }
    }
}
