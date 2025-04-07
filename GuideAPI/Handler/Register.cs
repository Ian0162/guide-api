using AutoMapper;
using GuideAPI.Dto;
using GuideAPI.Exceptions;
using GuideAPI.Filters;
using GuideAPI.Filters.Validators;
using GuideAPI.Services.Interface;
using MediatR;

namespace GuideAPI.Handler
{
    public class Register : IRequestHandler<IRegister, AuthResponseDto>
    {
        private readonly IMapper mapper;
        private readonly IAuthService service;
        public Register(IMapper mapper, IAuthService service)
        {
            this.mapper = mapper;
            this.service = service;
        }
        public async Task<AuthResponseDto> Handle(IRegister request, CancellationToken cancellationToken)
        {
            var validator = new RegisterFilter(service);
            var isValidated = await validator.ValidateAsync(request);
            if (isValidated.Errors.Any())
            {
                throw new BadRequestException("Invalid Request");
            }
            var mapped = mapper.Map<AuthRequestDto>(request);
            await service.Register(mapped);

            return new AuthResponseDto { };
        }
    }
}
