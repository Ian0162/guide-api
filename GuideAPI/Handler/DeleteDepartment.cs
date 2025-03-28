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
                    throw ThrowHttpException.Throw(
                        HttpStatusCode.BadRequest,
                        "Bad Request",
                        ""
                    );
                }

                var data = await service.CheckIdIfExist(request.Id);

                if (data == null)
                {
                    throw ThrowHttpException.Throw(
                        HttpStatusCode.NotFound,
                        "Data not exist",
                        ""
                    );
                }

                var result = await service.DeleteDepartment(request.Id);

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
