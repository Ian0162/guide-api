using FluentValidation;
using GuideAPI.Services.Interface;

namespace GuideAPI.Filters.Validators
{
    public class AuthFilter : AbstractValidator<IAuthenticate>
    {
        private readonly IAuthService service;
        public AuthFilter(IAuthService service)
        {
            RuleFor(key => key.Email)
                .EmailAddress()
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull();

            RuleFor(key => key.Password)
               .NotEmpty().WithMessage("{PropertyName} is required")
               .NotNull();

            this.service = service;
        }
    }
}
