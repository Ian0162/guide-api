using FluentValidation;
using GuideAPI.Services.Interface;

namespace GuideAPI.Filters.Validators
{
    public class CreateDepartmentFilter : AbstractValidator<ICreateDepartment>
    {
        private readonly IDepartmentService service;
        public CreateDepartmentFilter(IDepartmentService service)
        {
            RuleFor(key => key.departmentName)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull();

            RuleFor(key => key.isHidden)
                .Must(value => value == true || value == false)
                .WithMessage("{PropertyName} is reqtestuired");

            this.service = service;
        }
    }
}
