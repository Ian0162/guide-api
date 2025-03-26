using GuideAPI.Dto;
using MediatR;

namespace GuideAPI.Filters
{
    public class ICreateDepartment : IRequest<CreateUpdateResponse>
    {
        public string departmentName { get; set; }
        public bool? isHidden { get; set; }
        public ICreateDepartment(CreateDepartmentDto request) {
            this.departmentName = request.departmentName;
            this.isHidden = request.isHidden;
        }
    }
}
