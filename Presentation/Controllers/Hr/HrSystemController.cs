using Application.EntitiesOperations.HrSystem.Command.Create;
using Application.EntitiesOperations.HrSystem.Command.Delete;
using Application.EntitiesOperations.HrSystem.Command.Update;
using Application.EntitiesOperations.HrSystem.Query.Read;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Presentation.Controllers.@base;

namespace Presentation.Controllers.Hr
{
    [Authorize(Roles = "SuperAdmin")]

    public class HrSystemController : ApiController
    {
        [HttpPost("hr")]
        public async Task<IActionResult> Enroll([FromForm] CreateHrDto input ,CancellationToken cancellationToken)
        {
            var result = await Sender.Send(input,cancellationToken);

            if (result.IsSuccess)
                return Ok(result.Value);

            return BadRequest(new { Errors = result.Error });

        }
        
        

        [HttpPut]
        public async Task<IActionResult> EditHrSystem([FromForm] EditHrDto input, CancellationToken cancellationToken)
        {
            var result = await Sender.Send(input, cancellationToken);

            if (result.IsSuccess)
                return Ok(result.Value);

            return BadRequest(new { Errors = result.Error });

        }


        [HttpDelete]
        public async Task<IActionResult> DeleteHrSystem([FromBody] DeleteFromHrSystem id, CancellationToken cancellationToken)
        {
            var result = await Sender.Send(id, cancellationToken);

            if (result.IsSuccess)
                return Ok(result.Value);

            return BadRequest(new { Errors = result.Error });
        }


        [HttpGet]
        public async Task<IActionResult> GetHrSystem(CancellationToken cancellationToken)
        {
            return Ok( await Sender.Send(new GetAllHrQuery(), cancellationToken));

        }

    }
}



