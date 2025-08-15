using Application.EntitiesOperations.Trainee;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Presentation.Controllers.@base;

namespace Presentation.Controllers.Trainee
{
    //[Authorize(Roles = "Coordinator")]
    public class TraineeController : ApiController
    {
        private readonly ITraineeServices _traineeServices;
        public TraineeController(ITraineeServices traineeServices)
        {
            _traineeServices = traineeServices;
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CreateTraineeDto input, CancellationToken cancellationToken = default)
        {

            return Ok(await _traineeServices.Create(input,cancellationToken));

        }

        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken = default)
        {
            return Ok(await _traineeServices.Read(cancellationToken));

        }

        [HttpPut]
        public async Task<IActionResult> Update([FromForm] EditTraineeDto input, CancellationToken cancellationToken = default)
        {
            var res = await _traineeServices.Update(input, cancellationToken);

            if (res.IsSuccess)
                return Ok(res.Value);
            else
                return BadRequest(res.Error.Message);

        }


        [HttpDelete]
        public async Task<IActionResult> Delete([FromForm] DeleteTrainee input, CancellationToken cancellationToken = default)
        {
            var res = await _traineeServices.Delete(input, cancellationToken);

            if (res.IsSuccess)
                return Ok(res.Value);
            else
                return BadRequest(res.Error.Message);

        }

    }
}


