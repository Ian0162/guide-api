using AutoMapper;
using Azure;
using GuideAPI.Dto;
using GuideAPI.Exceptions;
using GuideAPI.Filters.Validators;
using GuideAPI.Repositories;
using GuideAPI.Services.Interface;

namespace GuideAPI.Services
{
    public class Department : IDepartmentService
    {
        private readonly IDepartment<Models.Department> repository;
        private readonly IMapper mapper;
        public Department(IMapper mapper, IDepartment<Models.Department> repository) {
            this.mapper = mapper;
            this.repository = repository;
        }

        public async Task<DepartmentTableResponse<Models.Department>> GetAllDepartmentPagination(DepartmentTableDto request)
        {
            try
            {
                var result = await repository.GetAllDepartmentPagination(request);
                if (result.isErr) throw new InternalServerException("", 500, "Internal Server Error");

                return result;
            }
            catch (Exception err)
            {
                var response = new
                {
                    code = 500,
                    message = "Internal Server Error",
                    details = err.Message
                };


                throw new InternalServerException(response.message, response.code, response.details);
            }
        }
    }
}
