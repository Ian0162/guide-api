using AutoMapper;
using Azure.Core;
using GuideAPI.Dto;
using GuideAPI.Exceptions;
using GuideAPI.Filters;
using GuideAPI.Filters.Validators;
using GuideAPI.Services.Interface;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Web.Http;

namespace GuideAPI.Handler
{
    public class CreateDepartment : IRequestHandler<ICreateDepartment, DefaultResponse>
    {
        private readonly IMapper mapper;
        private readonly IDepartmentService service;
        public CreateDepartment(IMapper mapper, IDepartmentService service) {
            this.mapper = mapper;
            this.service = service;   
        }

        public async Task<DefaultResponse> Handle(ICreateDepartment request, CancellationToken cancellationToken)
        {
            try
            {
                // Payload Validator
                var validator = new CreateDepartmentFilter(service);
                var isValidated = await validator.ValidateAsync(request);
                if (isValidated.Errors.Any())
                {
                    return ThrowHttp.Response(true, 400, "Invalid Request");
                }
                var isExist = await service.CheckDepartmentNameIfExist(request.departmentName);
                if (!string.IsNullOrEmpty(isExist?.departmentName))
                {
                    return ThrowHttp.Response(true, 409, "Department Already Exist, Conflict Detected");
                }
                var mapped = mapper.Map<CreateDepartmentDto>(request);
                await service.CreateDepartment(mapped);
                return ThrowHttp.Response(false, 201, "Created Successfully");
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
