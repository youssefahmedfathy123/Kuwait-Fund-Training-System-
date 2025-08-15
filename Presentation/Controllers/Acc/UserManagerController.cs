using Application.Auth.Commands.RoleManager;
using Application.Auth.Commands.UserManager;
using Gatherly.Domain.Shared;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Presentation.Controllers.@base;
using System.Threading;

namespace Presentation.Controllers.Acc
{
    [Authorize(Roles = "SuperAdmin")]
    public sealed class UserManagerController : ApiController
    {
        [HttpPost("AddPermissionToUser")]
        public async Task<IActionResult> AddPermissionToUser([FromForm] AddPermissionToUserCommand request, CancellationToken cancellationToken)
        {
            Result<string> result = await Sender.Send(request, cancellationToken);


            if (result.IsSuccess)
                return Ok(new { Success = result.Value });

            return BadRequest(new { Errors = result.Error });

        }


        [HttpPost("RemovePermissionFromUser")]
        public async Task<IActionResult> RemovePermissionFromUser([FromForm] RemovePermissionFromUserCommand request, CancellationToken cancellationToken)
        {

            Result<string> result = await Sender.Send(request, cancellationToken);


            if (result.IsSuccess)
                return Ok(new { Success = result.Value });

            return BadRequest(new { Errors = result.Error });
        }


        [HttpPost("AddRoleToUser")]
        public async Task<IActionResult> AddRoleToUser([FromForm] AddRoleToUserCommand request, CancellationToken cancellationToken)
        {


            Result<string> result = await Sender.Send(request, cancellationToken);


            if (result.IsSuccess)
                return Ok(new { Success = result.Value });

            return BadRequest(new { Errors = result.Error });

        }


        [HttpPost("RemoveRoleFromUser")]
        public async Task<IActionResult> RemoveRoleFromUser([FromForm] RemoveRoleFromUserCommand request, CancellationToken cancellationToken)
        {


            Result<string> result = await Sender.Send(request, cancellationToken);


            if (result.IsSuccess)
                return Ok(new { Success = result.Value });

            return BadRequest(new { Errors = result.Error });

        }



    }
}



