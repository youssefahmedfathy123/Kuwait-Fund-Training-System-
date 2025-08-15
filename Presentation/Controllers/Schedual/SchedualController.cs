using Application;
using Application.EntitiesOperations.Schedual;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Presentation.Controllers.@base;

namespace Presentation.Controllers.Schedual
{
    public class SchedualController : ApiController
    {
        private readonly ISchedualServices _SchedualServices;
        public SchedualController(ISchedualServices SchedualServices)
        {
            _SchedualServices = SchedualServices;
        }
        [Authorize(Roles = "Coordinator,Trainer")]

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CreateSchedualDto input, CancellationToken cancellationToken = default)
        {

            return Ok(await _SchedualServices.Create(input, cancellationToken));

        }

        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken = default)
        {
            return Ok(await _SchedualServices.Read(cancellationToken));

        }
        [Authorize(Roles = "Coordinator,Trainer")]

        [HttpPut]
        public async Task<IActionResult> Update([FromForm] UpdateSchedualDto input, CancellationToken cancellationToken = default)
        {
            var res = await _SchedualServices.Update(input, cancellationToken);

            if (res.IsSuccess)
                return Ok(res.Value);
            else
                return BadRequest(res.Error.Message);

        }

        [Authorize(Roles = "Coordinator,Trainer")]

        [HttpDelete]
        public async Task<IActionResult> Delete([FromForm] DeleteTable input, CancellationToken cancellationToken = default)
        {
            var res = await _SchedualServices.Delete(input, cancellationToken);

            if (res.IsSuccess)
                return Ok(res.Value);
            else
                return BadRequest(res.Error.Message);

        }

    }
}
