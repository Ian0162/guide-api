using GuideAPI.Dto;
using Microsoft.AspNetCore.Identity;

namespace GuideAPI.Services.Interface
{
    public interface IAuthService
    {
        public Task<AuthResponseDto> Login(AuthRequestDto request);
        public Task<IEnumerable<IdentityError>> Register(AuthRequestDto request);

    }
}
