using AutoMapper;
using GuideAPI.Dto;
using GuideAPI.Exceptions;
using GuideAPI.Filters;
using GuideAPI.Filters.Validators;
using GuideAPI.Services.Interface;
using MediatR;
using System.Net;

namespace GuideAPI.Handler
{
    public class DeleteDepartment : IRequestHandler<IDeleteDepartment, DefaultResponse>
    {
        private readonly IMapper mapper;
        private readonly IDepartmentService service;
        public DeleteDepartment(IMapper mapper, IDepartmentService service) { 
            this.mapper = mapper;
            this.service = service;
        }

        public async Task<DefaultResponse> Handle(IDeleteDepartment request, CancellationToken cancellationToken)
        {
            try {
                // Payload Validator
                var validator = new DeleteDepartmentFilter(service);
                var isValidated = await validator.ValidateAsync(request);
                if (isValidated.Errors.Any())
                {
                    return ThrowHttp.Response(true, 400, "Invalid Request");
                }
                var data = await service.CheckIdIfExist(request.Id);

                if (data == null)
                {
                    return ThrowHttp.Response(true, 404, "Department Not Found");
                }
                await service.DeleteDepartment(request.Id);
                return ThrowHttp.Response(false, 200, "Removed Successfully");
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
