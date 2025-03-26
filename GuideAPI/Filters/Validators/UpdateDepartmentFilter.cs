using FluentValidation;
using GuideAPI.Services.Interface;

namespace GuideAPI.Filters.Validators
{
    public class UpdateDepartmentFilter : AbstractValidator<IUpdateDepartment>
    {
        private readonly IDepartmentService service;
        public UpdateDepartmentFilter(IDepartmentService service)
        {
            RuleFor(key => key.departmentName)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .When(x => !string.IsNullOrEmpty(x.departmentName));

            RuleFor(key => key.isHidden)
                .Must(value => value == true || value == false)
                .WithMessage("{PropertyName} is reqtestuired")
                .When(x => !string.IsNullOrEmpty(x.isHidden.ToString()));

            this.service = service;
        }
    }
}
