using AutoMapper;
using GuideAPI.Dto;
using GuideAPI.Exceptions;
using GuideAPI.Filters;
using GuideAPI.Filters.Validators;
using GuideAPI.Models;
using GuideAPI.Services.Interface;
using MediatR;

namespace GuideAPI.Handler
{
    public class CreateDepartment : IRequestHandler<ICreateDepartment, CreateUpdateResponse>
    {
        private readonly IMapper mapper;
        private readonly IDepartmentService service;
        public CreateDepartment(IMapper mapper, IDepartmentService service) {
            this.mapper = mapper;
            this.service = service;   
        }

        public async Task<CreateUpdateResponse> Handle(ICreateDepartment request, CancellationToken cancellationToken)
        {
            try
            {
                // Payload Validator
                var validator = new CreateDepartmentFilter(service);
                var isValidated = await validator.ValidateAsync(request);

                if (isValidated.Errors.Any())
                {
                    throw new InvalidPayloadException("Invalid", 400, isValidated);
                }

                var mapped = mapper.Map<CreateDepartmentDto>(request);

                var result = await service.CreateDepartment(mapped);

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
