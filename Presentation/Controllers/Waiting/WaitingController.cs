using Application;
using Application.EntitiesOperations.Waiting;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Presentation.Controllers.@base;

namespace Presentation.Controllers.Waiting
{
    [Authorize(Roles = "Coordinator")]
    public class WaitingController : ApiController
    {
        private readonly IWaitingServices _waitingServices;
        public WaitingController(IWaitingServices WaitingServices)
        {
            _waitingServices = WaitingServices;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CreateWaitingDto input, CancellationToken cancellationToken = default)
        {

            return Ok(await _waitingServices.Create(input, cancellationToken));

        }

        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken = default)
        {
            return Ok(await _waitingServices.Read(cancellationToken));

        }

        [HttpPut]
        public async Task<IActionResult> Update([FromForm] UpdateWaitingDto input, CancellationToken cancellationToken = default)
        {
            var res = await _waitingServices.Update(input, cancellationToken);

            if (res.IsSuccess)
                return Ok(res.Value);
            else
                return BadRequest(res.Error.Message);

        }


        [HttpDelete]
        public async Task<IActionResult> Delete([FromForm] DeleteTable input, CancellationToken cancellationToken = default)
        {
            var res = await _waitingServices.Delete(input, cancellationToken);

            if (res.IsSuccess)
                return Ok(res.Value);
            else
                return BadRequest(res.Error.Message);

        }

    }
}


