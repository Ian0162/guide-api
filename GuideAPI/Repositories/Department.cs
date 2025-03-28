using GuideAPI.Data;
using GuideAPI.Dto;
using GuideAPI.Models;
using GuideAPI.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace GuideAPI.Repositories
{
    public class Department<T>: IDepartment<T> where T : BaseModel
    {
        protected readonly DBContext context;
        public Department(DBContext context)
        {
            this.context = context;
        }

        public async Task<Department> CheckDepartmentNameIfExist(string departmentName) => await context.departments.SingleOrDefaultAsync(col => col.departmentName == departmentName);
        public async Task<Department> CheckIdIfExist(int Id) => await context.departments.FindAsync(Id);

        public async Task<DepartmentTableResponse<Models.Department>> GetAllDepartmentPagination(DepartmentTableDto pagination)
        {
            IQueryable<Models.Department> List = context.departments.Where(col => col.DeletedAt == null);

            var skip = (pagination.page - 1) * pagination.rowsPerPage;

            if (!string.IsNullOrEmpty(pagination.startDate.ToString()) &&
            !string.IsNullOrEmpty(pagination.endDate.ToString()))
            {
                // Query For Checking Date (Created)
                List = List.Where(date =>
                    pagination.startDate <= DateOnly.FromDateTime((DateTime)date.CreatedAt)
                    &&
                    DateOnly.FromDateTime((DateTime)date.CreatedAt) <= pagination.endDate);
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
                .OrderByDescending(ob => ob.CreatedAt)
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

        public async Task<DefaultResponse> CreateDepartment(CreateDepartmentDto request)
        {
            var department = new Department
            {
                departmentName = request.departmentName,
                isHidden = request.isHidden,
                CreatedAt = DateTimeOffset.UtcNow.DateTime
            };

            await context.departments.AddAsync(department);
            var result = await context.SaveChangesAsync();

            if(result > 0)
            {
                 // Throw Err
            }

            var response = new DefaultResponse
            {
                Id = department.Id,
            };
            return response;

        }

        public async Task<DefaultResponse> UpdateDepartment(Models.Department data, UpdateDepartmentDto request, int Id)
        {
            foreach (PropertyInfo property in request.GetType().GetProperties())
            {
                var value = property.GetValue(request);

                if (value != null)
                {

                    var modelProperty = data.GetType().GetProperty(property.Name);
                    if (modelProperty != null && modelProperty.CanWrite)
                    {
                        data.UpdatedAt = DateTime.UtcNow;
                        modelProperty.SetValue(data, value);
                    }
                }
            }

            var result = await context.SaveChangesAsync();

            if (result > 0)
            {
                // Throw Err
            }

            var response = new DefaultResponse
            {
                Id = Id,
            };
            return response;
        }

        public async Task<DefaultResponse> DeleteDepartment(int Id)
        {
            var data = await context.departments.FindAsync(Id);

            if (data != null)
            {
                data.DeletedAt = DateTime.UtcNow;
                context.departments.Entry(data).State = EntityState.Modified;
                await context.SaveChangesAsync();
            }

            var response = new DefaultResponse
            {
                Id = Id,
            };
            return response;
        }

        //public async Task RestoreAsync(int id)
        //{
        //    var entity = await _dbSet.IgnoreQueryFilters().FirstOrDefaultAsync(e => e.Id == id);
        //    if (entity != null)
        //    {
        //        entity.DeletedAt = null;
        //        _context.Entry(entity).State = EntityState.Modified;
        //        await _context.SaveChangesAsync();
        //    }
        //}
    }
}
