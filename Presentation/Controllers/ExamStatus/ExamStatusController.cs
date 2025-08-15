using Application;
using Application.EntitiesOperations.ExamStatus;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Presentation.Controllers.@base;

namespace Presentation.Controllers.ExamStatus
{
    [Authorize(Roles = "Coordinator,Trainer")]

    public class ExamStatusController : ApiController
    {
        private readonly IExamStatusServices _examStatusServices;
        public ExamStatusController(IExamStatusServices examStatusServices)
        {
            _examStatusServices = examStatusServices;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CreateExamStatusDto input, CancellationToken cancellationToken = default)
        {

            return Ok(await _examStatusServices.Create(input, cancellationToken));

        }

        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken = default)
        {
            return Ok(await _examStatusServices.Read(cancellationToken));

        }

        [HttpPut]
        public async Task<IActionResult> Update([FromForm] UpdateExamStatusDto input, CancellationToken cancellationToken = default)
        {
            var res = await _examStatusServices.Update(input, cancellationToken);

            if (res.IsSuccess)
                return Ok(res.Value);
            else
                return BadRequest(res.Error.Message);

        }


        [HttpDelete]
        public async Task<IActionResult> Delete([FromForm] DeleteTable input, CancellationToken cancellationToken = default)
        {
            var res = await _examStatusServices.Delete(input, cancellationToken);

            if (res.IsSuccess)
                return Ok(res.Value);
            else
                return BadRequest(res.Error.Message);

        }

        [HttpGet("TopTwo")]
        public async Task<IActionResult> TopTwo(Guid Id, CancellationToken cancletionToken)
        {
           var Top =  await _examStatusServices.TopTwo(Id, cancletionToken);
            if (Top == null)
                return Ok("No One");

            return Ok(Top);      
        }


    }
}


