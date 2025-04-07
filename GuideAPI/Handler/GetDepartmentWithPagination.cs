using AutoMapper;
using GuideAPI.Dto;
using GuideAPI.Exceptions;
using GuideAPI.Filters;
using GuideAPI.Filters.Validators;
using GuideAPI.Models;
using GuideAPI.Services.Interface;
using MediatR;
using System.Net;

namespace GuideAPI.Handler
{
    public class GetDepartmentWithPagination : IRequestHandler<IDepartmentPagination, DepartmentTableResponse<Department>>
    {
        private readonly IMapper mapper;
        private readonly IDepartmentService service;
        public GetDepartmentWithPagination(IMapper mapper, IDepartmentService service) {
            this.mapper = mapper;
            this.service = service;
        }

        public async Task<DepartmentTableResponse<Department>> Handle(IDepartmentPagination request, CancellationToken cancellationToken) 
        {
            var validator = new DepartmentPaginationFilter(service);
            var isValidated = await validator.ValidateAsync(request);

            if (isValidated.Errors.Any())
            {
                throw new BadRequestException("Invalid Request");
            }

            var mapped = mapper.Map<DepartmentTableDto>(request);

            var result = await service.GetAllDepartmentPagination(mapped);

            return result;
        }
    }
}
