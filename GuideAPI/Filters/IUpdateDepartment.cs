using GuideAPI.Dto;
using MediatR;

namespace GuideAPI.Filters
{
    public class IUpdateDepartment : IRequest<DefaultResponse>
    {
        public int Id;

        public string? departmentName { get; set; }
        public bool? isHidden { get; set; }
        public IUpdateDepartment(UpdateDepartmentDto request)
        {
            this.departmentName = request.departmentName;
            this.isHidden = request.isHidden;
        }

        public IUpdateDepartment(UpdateDepartmentDto request, int Id) : this(request)
        {
            this.Id = Id;
        }
    }
}
