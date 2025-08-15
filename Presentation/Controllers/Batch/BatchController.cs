using Application.EntitiesOperations.Batch.Command;
using Application.EntitiesOperations.Company.Query;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Presentation.Controllers.@base;

namespace Presentation.Controllers.Batch
{
    [Authorize(Roles ="Coordinator")]
    public sealed class BatchController : ApiController
    {
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CreateBatchDto input, CancellationToken cancellationToken = default)
        {
            var res = await Sender.Send(input, cancellationToken);

            return Ok(new { Status = res});

        }

        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken = default)
        {
            return Ok(await Sender.Send(new GetAllCompanies(), cancellationToken));
            
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromForm] EditBatchDto input, CancellationToken cancellationToken = default)
        {
            var res = await Sender.Send(input, cancellationToken);

            if (res.IsSuccess)
                return Ok(res.Value);
            else
                return BadRequest(res.Error.Message);

        }


        [HttpDelete]
        public async Task<IActionResult> Delete([FromForm] DeleteBatch input, CancellationToken cancellationToken = default)
        {
            var res = await Sender.Send(input, cancellationToken);

            if (res.IsSuccess)
                return Ok(res.Value);
            else
                return BadRequest(res.Error.Message);

        }

    }


}


