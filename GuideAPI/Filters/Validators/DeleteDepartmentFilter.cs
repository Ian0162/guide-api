using FluentValidation;
using GuideAPI.Services.Interface;

namespace GuideAPI.Filters.Validators
{
    public class DeleteDepartmentFilter : AbstractValidator<IDeleteDepartment>
    {
        private readonly IDepartmentService service;
        public DeleteDepartmentFilter(IDepartmentService service)
        {
            RuleFor(key => key.Id)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull();

            this.service = service;
        }
    }
}
