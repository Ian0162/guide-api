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
            // Payload Validator
            var validator = new DeleteDepartmentFilter(service);
            var isValidated = await validator.ValidateAsync(request);
            if (isValidated.Errors.Any())
            {
                throw new BadRequestException("Invalid Request");
            }
            var data = await service.CheckIdIfExist(request.Id);

            if (data == null)
            {
                throw new NotFoundException(nameof(Handle), request.Id);
            }
            await service.DeleteDepartment(request.Id);
            return new DefaultResponse { };
        }
    }
}
