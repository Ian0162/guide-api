using AutoMapper;
using GuideAPI.Dto;
using GuideAPI.Exceptions;
using GuideAPI.Filters;
using GuideAPI.Filters.Validators;
using GuideAPI.Services.Interface;
using MediatR;

namespace GuideAPI.Handler
{
    public class AuthLogin : IRequestHandler<IAuthenticate, AuthResponseDto>
    {
        private readonly IMapper mapper;
        private readonly IAuthService service;

        public AuthLogin(IMapper mapper, IAuthService service)
        {
            this.mapper = mapper;
            this.service = service;
        }

        public async Task<AuthResponseDto> Handle(IAuthenticate request, CancellationToken cancellationToken)
        {
            // Payload Validator
            var validator = new AuthFilter(service);
            var isValidated = await validator.ValidateAsync(request);
            if (isValidated.Errors.Any())
            {
                throw new BadRequestException("Invalid Request");
            }

            var mapped = mapper.Map<AuthRequestDto>(request);
            var result = await service.Login(mapped);

            if(result == null)
            {
                throw new UnauthorizedException("Unauthorized");
            }

            return result;
        }

    }
}
