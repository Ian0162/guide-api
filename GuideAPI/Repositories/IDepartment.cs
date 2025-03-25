
using GuideAPI.Dto;

namespace GuideAPI.Repositories
{
    public interface IDepartment<T> where T : class
    {
        public Task<DepartmentTableResponse<Models.Department>> GetAllDepartmentPagination(DepartmentTableDto request); 
    }
}
