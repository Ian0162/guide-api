using GuideAPI.Dto;

namespace GuideAPI.Repositories.Interface
{
    public interface IDepartment<T> where T : class
    {
        public Task<DepartmentTableResponse<Models.Department>> GetAllDepartmentPagination(DepartmentTableDto request); 
        public Task<DefaultResponse> CreateDepartment(CreateDepartmentDto request);
        public Task<DefaultResponse> UpdateDepartment(Models.Department data, UpdateDepartmentDto request, int Id);
        public Task<DefaultResponse> DeleteDepartment(int Id);
        public Task<Models.Department> CheckDepartmentNameIfExist(string name);
        public Task<Models.Department> CheckIdIfExist(int Id);
    }
}
