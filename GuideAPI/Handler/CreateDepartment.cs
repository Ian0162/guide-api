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
            // Payload Validator
            var validator = new CreateDepartmentFilter(service);
            var isValidated = await validator.ValidateAsync(request);
            if (isValidated.Errors.Any())
            {
                throw new BadRequestException("Invalid Request");
            }
            var isExist = await service.CheckDepartmentNameIfExist(request.departmentName);
            if (!string.IsNullOrEmpty(isExist?.departmentName))
            {
                throw new ConflictException(nameof(Handle), isExist.departmentName);
            }
            var mapped = mapper.Map<CreateDepartmentDto>(request);
            await service.CreateDepartment(mapped);

            return new DefaultResponse { };
        }
    }
}
