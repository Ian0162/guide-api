using GuideAPI.Dto;
using MediatR;

namespace GuideAPI.Filters
{
    public class IAuthenticate : IRequest<AuthResponseDto>
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public IAuthenticate(AuthRequestDto request)
        {
            this.Email = request.Email;
            this.Password = request.Password;
        }
    }
}
