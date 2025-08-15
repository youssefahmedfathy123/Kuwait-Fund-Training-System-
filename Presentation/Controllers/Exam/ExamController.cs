using Application;
using Application.EntitiesOperations.Exam;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Presentation.Controllers.@base;

namespace Presentation.Controllers.Exam
{
    [Authorize(Roles = "Coordinator,Trainer")]
    public class ExamController : ApiController
    {
        private readonly IExamServices _examServices;
        public ExamController(IExamServices examServices)
        {
            _examServices = examServices;
        }


        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CreateExamDto input, CancellationToken cancellationToken = default)
        {

            return Ok(await _examServices.Create(input, cancellationToken));

        }

        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken = default)
        {
            return Ok(await _examServices.Read(cancellationToken));

        }


        [HttpPut]
        public async Task<IActionResult> Update([FromForm] UpdateExamDto input, CancellationToken cancellationToken = default)
        {
            var res = await _examServices.Update(input, cancellationToken);

            if (res.IsSuccess)
                return Ok(res.Value);
            else
                return BadRequest(res.Error.Message);

        }




        [HttpDelete]
        public async Task<IActionResult> Delete([FromForm] DeleteTable input, CancellationToken cancellationToken = default)
        {
            var res = await _examServices.Delete(input, cancellationToken);

            if (res.IsSuccess)
                return Ok(res.Value);
            else
                return BadRequest(res.Error.Message);

        }

    }
}
