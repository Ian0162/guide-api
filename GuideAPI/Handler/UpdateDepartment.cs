using AutoMapper;
using GuideAPI.Dto;
using GuideAPI.Exceptions;
using GuideAPI.Filters;
using GuideAPI.Filters.Validators;
using GuideAPI.Services.Interface;
using MediatR;

namespace GuideAPI.Handler
{
    public class UpdateDepartment : IRequestHandler<IUpdateDepartment, CreateUpdateResponse>
    {
        public readonly IMapper mapper;
        public readonly IDepartmentService service;
        public UpdateDepartment(IMapper mapper, IDepartmentService service) {
            this.mapper = mapper;
            this.service = service;
        }

        public async Task<CreateUpdateResponse> Handle(IUpdateDepartment request , CancellationToken cancellationToken)
        {
            try
            {
                // Payload Validator
                var validator = new UpdateDepartmentFilter(service);
                var isValidated = await validator.ValidateAsync(request);

                if (isValidated.Errors.Any())
                {
                    throw new InvalidPayloadException("Invalid", 400, isValidated);
                }

                var mapped = mapper.Map<UpdateDepartmentDto>(request);

                var result = await service.UpdateDepartment(mapped, request.Id);

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
