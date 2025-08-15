using Application;
using Application.EntitiesOperations.Honor;
using Application.EntitiesOperations.Trainee;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Presentation.Controllers.@base;

namespace Presentation.Controllers.Honor
{
    [Authorize(Roles = "Coordinator,Trainer")]
    public class HonorController : ApiController
    {
        private readonly IHonorServices _honorServices;
        public HonorController(IHonorServices honorServices)
        {
            _honorServices = honorServices;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CreateHonorDto input, CancellationToken cancellationToken = default)
        {

            return Ok(await _honorServices.Create(input, cancellationToken));

        }

        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken = default)
        {
            return Ok(await _honorServices.Read(cancellationToken));

        }

        [HttpPut]
        public async Task<IActionResult> Update([FromForm] UpdateHonorDto input, CancellationToken cancellationToken = default)
        {
            var res = await _honorServices.Update(input, cancellationToken);

            if (res.IsSuccess)
                return Ok(res.Value);
            else
                return BadRequest(res.Error.Message);

        }


        [HttpDelete]
        public async Task<IActionResult> Delete([FromForm] DeleteTable input, CancellationToken cancellationToken = default)
        {
            var res = await _honorServices.Delete(input, cancellationToken);

            if (res.IsSuccess)
                return Ok(res.Value);
            else
                return BadRequest(res.Error.Message);

        }

    }
}
