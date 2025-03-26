using GuideAPI.Dto;

namespace GuideAPI.Repositories.Interface
{
    public interface IDepartment<T> where T : class
    {
        public Task<DepartmentTableResponse<Models.Department>> GetAllDepartmentPagination(DepartmentTableDto request); 
        public Task<CreateUpdateResponse> CreateDepartment(CreateDepartmentDto request);
        public Task<CreateUpdateResponse> UpdateDepartment(UpdateDepartmentDto request, int Id);
    }
}
