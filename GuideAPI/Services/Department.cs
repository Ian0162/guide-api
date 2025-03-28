using AutoMapper;
using Azure;
using Azure.Core;
using GuideAPI.Dto;
using GuideAPI.Exceptions;
using GuideAPI.Filters.Validators;
using GuideAPI.Handler;
using GuideAPI.Repositories.Interface;
using GuideAPI.Services.Interface;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace GuideAPI.Services
{
    public class Department : IDepartmentService
    {
        private readonly IDepartment<Models.Department> repository;
        private readonly IMapper mapper;
        public Department(IMapper mapper, IDepartment<Models.Department> repository)
        {
            this.mapper = mapper;
            this.repository = repository;
        }

        public async Task<Models.Department> CheckDepartmentNameIfExist(string departmentName) => await repository.CheckDepartmentNameIfExist(departmentName);
        public async Task<Models.Department> CheckIdIfExist(int Id) => await repository.CheckIdIfExist(Id);

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

        public async Task<DefaultResponse> CreateDepartment(CreateDepartmentDto request)
        {
            try
            {
                var result = await repository.CreateDepartment(request);
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

        public async Task<DefaultResponse> UpdateDepartment(Models.Department data, UpdateDepartmentDto request, int Id)
        {
            try
            {
                var result = await repository.UpdateDepartment(data, request, Id);
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

                Console.WriteLine(err.Message);


                throw new InternalServerException(response.message, response.code, response.details);
            }
        }
        public async Task<DefaultResponse> DeleteDepartment(int Id)
        {
            try
            {
                var result = await repository.DeleteDepartment(Id);
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

                Console.WriteLine(err.Message);


                throw new InternalServerException(response.message, response.code, response.details);
            }
        }
    }
}
