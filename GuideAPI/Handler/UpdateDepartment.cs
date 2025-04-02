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
            try
            {
                // Payload Validator
                var validator = new UpdateDepartmentFilter(service);
                var isValidated = await validator.ValidateAsync(request);
                if (isValidated.Errors.Any())
                {
                    return ThrowHttp.Response(true, 400, "Invalid Request");
                }
                if (!string.IsNullOrEmpty(request.departmentName))
                {
                    var isExist = await service.CheckDepartmentNameIfExist(request.departmentName);
                    if (!string.IsNullOrEmpty(isExist?.departmentName))
                    {
                        return ThrowHttp.Response(true, 409, "Department Already Exist, Conflict Detected");
                    }
                }
                var data = await service.CheckIdIfExist(request.Id);
                if (data == null)
                {
                    return ThrowHttp.Response(true, 404, "Department Not Found");
                }
                var mapped = mapper.Map<UpdateDepartmentDto>(request);
                await service.UpdateDepartment(data, mapped, request.Id);
                return ThrowHttp.Response(false, 200, "Updated Successfully");
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
