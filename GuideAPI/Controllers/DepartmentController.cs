using GuideAPI.Dto;
using GuideAPI.Filters;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GuideAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IMediator mediator;
        public DepartmentController(IMediator mediator) 
        {
            this.mediator = mediator; 
        }
        // POST: api/<DepartmentController>
        [HttpPost]
        public async Task<ActionResult<List<DepartmentTableDto>>> GetDataWithPagination(DepartmentTableDto request)
        {

            var result = await mediator.Send(new IDepartmentPagination(request));

            return Ok(result);
        }

        [HttpPost("create")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<CreateDepartmentDto>> CreateDepartment(CreateDepartmentDto request)
        {
            var result = await mediator.Send(new ICreateDepartment(request));

            return Ok(result);
        }

        [HttpPatch("update/{Id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<UpdateDepartmentDto>> UpdateDepartment(int Id, UpdateDepartmentDto request)
        {
            var result = await mediator.Send(new IUpdateDepartment(request, Id));

            return Ok(result);
        }

        [HttpDelete("delete/{Id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> DeleteDepartment(int Id)
        {
            await mediator.Send(new IDeleteDepartment(Id));
            return NoContent();
        }
    }
}
