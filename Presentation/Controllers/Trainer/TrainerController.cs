using Application.EntitiesOperations.Trainer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Presentation.Controllers.@base;

namespace Presentation.Controllers.Trainer
{
    [Authorize(Roles = "Coordinator,Trainer")]
    internal class TrainerController : ApiController
    {
        private readonly ITrainerServices _trainerServices;
        public TrainerController(ITrainerServices trainerServices)
        {
            _trainerServices = trainerServices;
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CreateTrainerDto input, CancellationToken cancellationToken = default)
        {

            return Ok(await _trainerServices.Create(input, cancellationToken));

        }

        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken = default)
        {
            return Ok(await _trainerServices.Read(cancellationToken));

        }

        [HttpPut]
        public async Task<IActionResult> Update([FromForm] UpdateTrainerDto input, CancellationToken cancellationToken = default)
        {
            var res = await _trainerServices.Update(input, cancellationToken);

            if (res.IsSuccess)
                return Ok(res.Value);
            else
                return BadRequest(res.Error.Message);

        }


        [HttpDelete]
        public async Task<IActionResult> Delete([FromForm] DeleteTrainer input, CancellationToken cancellationToken = default)
        {
            var res = await _trainerServices.Delete(input, cancellationToken);

            if (res.IsSuccess)
                return Ok(res.Value);
            else
                return BadRequest(res.Error.Message);

        }

    }
}


