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
                    throw ThrowHttpException.Throw(
                         HttpStatusCode.BadRequest,
                         "Invalid Data",
                         "Some required data is missing"
                    );
                }

                
                if (!string.IsNullOrEmpty(request.departmentName))
                {
                    var isExist = await service.CheckDepartmentNameIfExist(request.departmentName);


                    if (!string.IsNullOrEmpty(isExist?.departmentName))
                    {
                        throw ThrowHttpException.Throw(
                             HttpStatusCode.Conflict,
                             "Department Already Exist",
                             ""
                        );
                    }
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


                var mapped = mapper.Map<UpdateDepartmentDto>(request);

                var result = await service.UpdateDepartment(data, mapped, request.Id);

                return result;
            }
            catch (HttpResponseException)
            {
                throw;
            }
            catch (Exception err)
            {
                var response = new
                {
                    code = 500,
                    message = "Internal Server Error",
                    details = err.Message
                };

                throw ThrowHttpException.Throw(
                    HttpStatusCode.InternalServerError,
                    response.message,
                    response.details
                );

            }
        }
    }
}
