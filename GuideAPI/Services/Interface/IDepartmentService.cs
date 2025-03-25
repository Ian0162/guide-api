using GuideAPI.Dto;

namespace GuideAPI.Services.Interface
{
    public interface IDepartmentService
    {
        public Task<DepartmentTableResponse<Models.Department>> GetAllDepartmentPagination(DepartmentTableDto request);
    }
}
