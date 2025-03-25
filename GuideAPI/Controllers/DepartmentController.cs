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
    }
}
