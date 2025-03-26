using GuideAPI.Data;
using GuideAPI.Dto;
using GuideAPI.Exceptions;
using GuideAPI.Models;
using GuideAPI.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace GuideAPI.Repositories
{
    public class Department<T>: IDepartment<T> where T : BaseModel
    {
        protected readonly DBContext context;
        public Department(DBContext context)
        {
            this.context = context;
        }

        public async Task<DepartmentTableResponse<Models.Department>> GetAllDepartmentPagination(DepartmentTableDto pagination)
        {
            IQueryable<Models.Department> List = context.departments;

            var skip = (pagination.page - 1) * pagination.rowsPerPage;

            if (!string.IsNullOrEmpty(pagination.startDate.ToString()) &&
            !string.IsNullOrEmpty(pagination.endDate.ToString()))
            {
                // Query For Checking Date (Created)
                List = List.Where(date =>
                    pagination.startDate <= DateOnly.FromDateTime((DateTime)date.createdDate)
                    &&
                    DateOnly.FromDateTime((DateTime)date.createdDate) <= pagination.endDate);
            }

            if (!string.IsNullOrEmpty(pagination.searchString))
            {
                // Query For Search Based on User Input [N: Using OR'||' will include relationship]
                List = List.Where(search =>
                    search.departmentName.Contains(pagination.searchString)
                );
            }
         
            // Pagination (skip & take)
            var result = await List
                .Skip(skip)
                .Take(pagination.rowsPerPage)
                .OrderByDescending(ob => ob.Id)
            .ToListAsync();

            var start = result.Count == 0 ? 0 : (pagination.page - 1) * pagination.rowsPerPage + 1;
            var end = start + (result.Count > 0 ? result.Count - 1 : 0);

            var response = new DepartmentTableResponse<Models.Department>
            {
                data = result,
                total = result.Count,
                page = pagination.page,
                start = start,
                end = end,
                rowsPerPage = pagination.rowsPerPage,
                totalPages = (int)Math.Ceiling((double)result.Count / pagination.rowsPerPage)
            };

            return response;
        }

        public async Task<CreateUpdateResponse> CreateDepartment(CreateDepartmentDto request)
        {
            var isFound = await context.departments.SingleOrDefaultAsync(col => col.departmentName == request.departmentName);


            if(!string.IsNullOrEmpty(isFound?.departmentName))
            {
                Console.WriteLine("Existing");
                throw new Exception();
            }

            var department = new Department
            {
                departmentName = request.departmentName,
                isHidden = request.isHidden,
                createdDate = DateTimeOffset.UtcNow.DateTime
            };

            await context.departments.AddAsync(department);
            var result = await context.SaveChangesAsync();

            if(result > 0)
            {
                 // Throw Err
            }

            var response = new CreateUpdateResponse
            {
                Id = department.Id,
            };
            return response;

        }

        public async Task<CreateUpdateResponse> UpdateDepartment(UpdateDepartmentDto request, int Id)
        {
            var isExist = await context.departments.SingleOrDefaultAsync(col => col.departmentName == request.departmentName);


            if (!string.IsNullOrEmpty(isExist?.departmentName))
            {
                Console.WriteLine("Existing");
                throw new Exception();
            }

            var data = await context.departments.FirstOrDefaultAsync(get =>  get.Id == Id);

            if (data == null)
            {
                Console.WriteLine("Existing");
                throw new Exception();
            }

            context.departments.Entry(data).CurrentValues.SetValues(request);

            var result = await context.SaveChangesAsync();

            if (result > 0)
            {
                // Throw Err
            }

            var response = new CreateUpdateResponse
            {
                Id = Id,
            };
            return response;

        }
    }
}
