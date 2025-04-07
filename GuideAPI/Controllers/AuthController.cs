using GuideAPI.Dto;
using GuideAPI.Filters;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GuideAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator mediator;
        public AuthController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        // POST api/<AuthController>/login
        [HttpPost]
        [Route("login")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<AuthResponseDto>> AuthLogin(AuthRequestDto request)
        {
            var result = await mediator.Send(new IAuthenticate(request));

            return Ok(result);
        }

        [HttpPost]
        [Route("register")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> AuthRegister(AuthRequestDto request)
        {
            var result = await mediator.Send(new IRegister(request));

            return Ok(result);
        }

        //[HttpPost]
        //[Route("refreshtoken")]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //public async Task<ActionResult> RefreshToken([FromBody] AuthResponseDto request)
        //{
        //    var authResponse = await _authManager.VerifyRefreshToken(request);

        //    if (authResponse == null)
        //    {
        //        return Unauthorized();
        //    }

        //    return Ok(authResponse);
        //}
    }
}
