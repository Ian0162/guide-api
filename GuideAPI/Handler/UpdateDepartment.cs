using AutoMapper;
using GuideAPI.Dto;
using GuideAPI.Exceptions;
using GuideAPI.Filters;
using GuideAPI.Filters.Validators;
using GuideAPI.Services.Interface;
using MediatR;
using System.Net;
using System.Web.Http;

namespace GuideAPI.Handler
{
    public class UpdateDepartment : IRequestHandler<IUpdateDepartment, DefaultResponse>
    {
        public readonly IMapper mapper;
        public readonly IDepartmentService service;
        public UpdateDepartment(IMapper mapper, IDepartmentService service) {
            this.mapper = mapper;
            this.service = service;
        }

        public async Task<DefaultResponse> Handle(IUpdateDepartment request , CancellationToken cancellationToken)
        {
            
            var validator = new UpdateDepartmentFilter(service);
            var isValidated = await validator.ValidateAsync(request);
            if (isValidated.Errors.Any())
            {
                throw new BadRequestException("Invalid Request");
            }
            if (!string.IsNullOrEmpty(request.departmentName))
            {
                var isExist = await service.CheckDepartmentNameIfExist(request.departmentName);
                if (!string.IsNullOrEmpty(isExist?.departmentName))
                {
                    throw new ConflictException(nameof(Handle), isExist.departmentName);
                }
            }
            var data = await service.CheckIdIfExist(request.Id);
            if (data == null)
            {
                throw new NotFoundException(nameof(Handle), request.Id);
            }
            var mapped = mapper.Map<UpdateDepartmentDto>(request);
            await service.UpdateDepartment(data, mapped, request.Id);
            return new DefaultResponse { };
           
        }
    }
}
