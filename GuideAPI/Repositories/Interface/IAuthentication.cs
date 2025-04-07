using GuideAPI.Dto;
using Microsoft.AspNetCore.Identity;

namespace GuideAPI.Repositories.Interface
{
    public interface IAuthentication
    {
        public Task<AuthResponseDto> Login(AuthRequestDto request);
        public Task<IEnumerable<IdentityError>> Register(AuthRequestDto request);

    }
}
