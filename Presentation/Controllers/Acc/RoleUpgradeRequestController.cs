using Application.ApproveOrRejectRoleUpgradeRequest;
using Application.RoleUpgradeRequest;
using Gatherly.Domain.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Presentation.Controllers.@base;

namespace Presentation.Controllers.Acc
{

    [Authorize(Roles = "Admin")]
    public sealed class RoleUpgradeRequestController : ApiController
    {
        [HttpPost("AddUpgradeRoleRequest")]

        public async Task<IActionResult> AddUpgradeRoleRequest([FromForm]RoleUpgradeRequestCommand request,CancellationToken cancellation)
        {
            Result<string> result = await Sender.Send(request, cancellation);

            if (result.IsSuccess)
                return Ok(new { Success = result.Value });

            return BadRequest(new { Errors = result.Error });
        }



        [HttpPost("ApproveOrRejectTheRoleUpgradeRequest")]
        public async Task<IActionResult> ApproveOrRejectTheRoleUpgradeRequest([FromForm] ApproveOrRejectRoleUpgradeRequestCommand request, CancellationToken cancellation)
        {
            Result<string> result = await Sender.Send(request, cancellation);

            if (result.IsSuccess)
                return Ok(new { Success = result.Value });

            return BadRequest(new { Errors = result.Error });
        }


    }
}

