using Application.Auth.Commands.Registeration;
using Application.Auth.Queries.LoginOperation;
using Gatherly.Domain.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Presentation.Controllers.@base;

namespace Presentation.Controllers.Acc
{
    [AllowAnonymous]
    public sealed class AccountController : ApiController
    {

        [Authorize(Roles ="Coordinator")]
        [HttpPost("Register")]
        public async Task<IActionResult> AddToUsersTable([FromForm] RegisterCommand request, CancellationToken cancellationToken)
        {
            Result<string> result = await Sender.Send(request, cancellationToken);

            if (result.IsSuccess)
                return Ok(new { Token = result.Value });

            return BadRequest(new { Errors = result.Error });
        }







        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromForm] LoginCommand request, CancellationToken cancellationToken)
        {
            Result<string> result = await Sender.Send(request, cancellationToken);

            if (result.IsSuccess)
                return Ok(new { Token = result.Value });

            return BadRequest(new { Errors = result.Error });
        }


        //[HttpGet("logout")]
        //public async Task<IActionResult> Logout()
        //{
        //    return Ok("Signed out");
        //}


    }
}




//[HttpGet("{webinarId:guid}")]
//[ProducesResponseType(typeof(WebinarResponse), StatusCodes.Status200OK)]
//[ProducesResponseType(StatusCodes.Status404NotFound)]
//public async Task<IActionResult> GetWebinar(Guid webinarId, CancellationToken cancellationToken)
//{
//    var query = new GetWebinarByIdQuery(webinarId);

//    var webinar = await Sender.Send(query, cancellationToken);

//    return Ok(webinar);
//}



//[HttpPost]
//[ProducesResponseType(typeof(Guid), StatusCodes.Status201Created)]
//[ProducesResponseType(StatusCodes.Status400BadRequest)]
//public async Task<IActionResult> CreateWebinar(
//    [FromBody] CreateWebinarRequest request,
//    CancellationToken cancellationToken)
//{
//    var command = request.Adapt<CreateWebinarCommand>();

//    var webinarId = await Sender.Send(command, cancellationToken);

//    return CreatedAtAction(nameof(GetWebinar), new { webinarId }, webinarId);
//}




