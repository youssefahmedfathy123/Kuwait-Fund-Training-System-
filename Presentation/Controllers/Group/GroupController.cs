using Application.EntitiesOperations.Group.Command;
using Application.EntitiesOperations.Group.Query;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Presentation.Controllers.@base;

namespace Presentation.Controllers.Group
{
    [Authorize(Roles = "Coordinator,Trainer")]

    public class GroupController : ApiController
    {
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CreateGroupDto input, CancellationToken cancellationToken = default)
        {
            var res = await Sender.Send(input, cancellationToken);

            return Ok(new { Status = res });

        }

        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken = default)
        {
            return Ok(await Sender.Send(new GetAllGroups(), cancellationToken));

        }

        [HttpPut]
        public async Task<IActionResult> Update([FromForm] EditGroupDto input, CancellationToken cancellationToken = default)
        {
            var res = await Sender.Send(input, cancellationToken);

            if (res.IsSuccess)
                return Ok(res.Value);
            else
                return BadRequest(res.Error.Message);

        }


        [HttpDelete]
        public async Task<IActionResult> Delete([FromForm] DeleteGroup input, CancellationToken cancellationToken = default)
        {
            var res = await Sender.Send(input, cancellationToken);

            if (res.IsSuccess)
                return Ok(res.Value);
            else
                return BadRequest(res.Error.Message);

        }

    }
}
