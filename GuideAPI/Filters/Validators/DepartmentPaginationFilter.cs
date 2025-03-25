using FluentValidation;
using GuideAPI.Services.Interface;
namespace GuideAPI.Filters.Validators
{
    public class DepartmentPaginationFilter : AbstractValidator<IDepartmentPagination>
    {
        private readonly IDepartmentService service;
        public DepartmentPaginationFilter(IDepartmentService service) 
        {
            RuleFor(key => key.page)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull();

            RuleFor(key => key.rowsPerPage)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull();

            this.service = service;   
        }
    }
}
