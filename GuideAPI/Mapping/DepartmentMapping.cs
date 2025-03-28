using AutoMapper;
using GuideAPI.Dto;
using GuideAPI.Filters;
using GuideAPI.Models;

namespace GuideAPI.Mapping
{
    public class DepartmentMapping : Profile
    {
        public DepartmentMapping()
        {
            CreateMap<IDepartmentPagination, DepartmentTableDto>().ReverseMap();
            // Create
            CreateMap<CreateDepartmentDto, Department>().ReverseMap();
            CreateMap<ICreateDepartment, CreateDepartmentDto>().ReverseMap();
            // Update
            CreateMap<UpdateDepartmentDto, Department>().ReverseMap();
            CreateMap<IUpdateDepartment, UpdateDepartmentDto>().ReverseMap();

            // Tables
            CreateMap<DepartmentTableDto, DepartmentTableResponse<Department>>().ReverseMap();
        }
    }
}
