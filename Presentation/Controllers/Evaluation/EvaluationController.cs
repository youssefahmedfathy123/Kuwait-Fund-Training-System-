using Application;
using Application.EntitiesOperations.Evaluation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Presentation.Controllers.@base;

namespace Presentation.Controllers.Evaluation
{
    [Authorize(Roles = "Coordinator,Trainer")]

    public class EvaluationController : ApiController
    {
        private readonly IEvaluationServices _evaluationServices;
        public EvaluationController(IEvaluationServices evaluationServices)
        {
            _evaluationServices = evaluationServices;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CreateEvaluationDto input, CancellationToken cancellationToken = default)
        {

            return Ok(await _evaluationServices.Create(input, cancellationToken));

        }

        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken = default)
        {
            return Ok(await _evaluationServices.Read(cancellationToken));

        }

        [HttpPut]
        public async Task<IActionResult> Update([FromForm] UpdateEvaluationDto input, CancellationToken cancellationToken = default)
        {
            var res = await _evaluationServices.Update(input, cancellationToken);

            if (res.IsSuccess)
                return Ok(res.Value);
            else
                return BadRequest(res.Error.Message);

        }


        [HttpDelete]
        public async Task<IActionResult> Delete([FromForm] DeleteTable input, CancellationToken cancellationToken = default)
        {
            var res = await _evaluationServices.Delete(input, cancellationToken);

            if (res.IsSuccess)
                return Ok(res.Value);
            else
                return BadRequest(res.Error.Message);

        }



        [HttpPost("AddOrEditExamResult")]
        public async Task<IActionResult> AddOrEditExamResult(int Id, int value, CancellationToken cancletionToken)
        {
            return Ok(await _evaluationServices.AddOrEditExamResult(Id,value,cancletionToken));
        }



        [HttpPost("AddOrEditEvaluation")]
        public async Task<IActionResult> AddOrEditEvaluation(int Id, int value, CancellationToken cancletionToken)
        {
            return Ok(await _evaluationServices.AddOrEditEvaluation(Id, value, cancletionToken));

        }


      


    }
}
