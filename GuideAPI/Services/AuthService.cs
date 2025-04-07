using AutoMapper;
using GuideAPI.Dto;
using GuideAPI.Exceptions;
using GuideAPI.Repositories.Interface;
using GuideAPI.Services.Interface;
using Microsoft.AspNetCore.Identity;

namespace GuideAPI.Services
{
    public class AuthService : IAuthService
    {
        private readonly IAuthentication repository;
        public AuthService(IAuthentication repository) {
            this.repository = repository; 
        }

        public async Task<AuthResponseDto> Login(AuthRequestDto request)
        {

            try
            {
                var result = await repository.Login(request);               

                return result;
            }
            catch (Exception err)
            {
                var response = new
                {
                    code = 500,
                    message = "Internal Server Error",
                    details = err.Message
                };
                
                throw new InternalServerException(response.message, response.code, response.details);
            }
        }

        public async Task<IEnumerable<IdentityError>> Register(AuthRequestDto request)
        {

            try
            {
                var result = await repository.Register(request);

                return result;
            }
            catch (Exception err)
            {
                var response = new
                {
                    code = 500,
                    message = "Internal Server Error",
                    details = err.Message
                };

                throw new InternalServerException(response.message, response.code, response.details);
            }
        }
    }
}
