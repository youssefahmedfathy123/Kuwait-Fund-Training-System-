using Application.Auth.Commands.RoleManager;
using Gatherly.Domain.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Presentation.Controllers.@base;

namespace Presentation.Controllers.Acc
{
    [Authorize(Roles = "SuperAdmin")]
    public sealed class RoleManagerController : ApiController
    {
        [HttpPost("AddPermissionToRole")]
        public async Task<IActionResult> AddPermissionToRole([FromForm] AddPermissionToRoleCommand request, CancellationToken cancellationToken)
        {
            Result<string> result = await Sender.Send(request, cancellationToken);

            
            if (result.IsSuccess)
                return Ok(new { Success = result.Value });

            return BadRequest(new { Errors = result.Error });

        }


        [HttpPost("RemovePermissionFromRole")]
        public async Task<IActionResult> RemovePermissionFromRole([FromForm] RemovePermissionFromRoleCommand request, CancellationToken cancellationToken)
        {
            Result<string> result = await Sender.Send(request,cancellationToken);


            if (result.IsSuccess)
                return Ok(new { Success = result.Value });

            return BadRequest(new { Errors = result.Error });


        }
    }
}




