using Application;
using Application.EntitiesOperations.Feedback;
using Application.EntitiesOperations.Trainee;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Presentation.Controllers.@base;

namespace Presentation.Controllers.Feedback
{
    public class FeedbackController : ApiController
    {
        private readonly IFeedbackServices _FeedbackServices;
        public FeedbackController(IFeedbackServices FeedbackServices)
        {
            _FeedbackServices = FeedbackServices;
        }

        [Authorize(Roles = "Trainee")]

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CreateFeedbackDto input, CancellationToken cancellationToken = default)
        {

            return Ok(await _FeedbackServices.Create(input, cancellationToken));

        }

        [Authorize(Roles = "Coordinator,Trainer")]
        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken = default)
        {
            return Ok(await _FeedbackServices.Read(cancellationToken));

        }


        //[HttpPut]
        //public async Task<IActionResult> Update([FromForm] UpdateFeedbackDto input, CancellationToken cancellationToken = default)
        //{
        //    var res = await _FeedbackServices.Update(input, cancellationToken);

        //    if (res.IsSuccess)
        //        return Ok(res.Value);
        //    else
        //        return BadRequest(res.Error.Message);

        //}


        //[HttpDelete]
        //public async Task<IActionResult> Delete([FromForm] DeleteTable input, CancellationToken cancellationToken = default)
        //{
        //    var res = await _FeedbackServices.Delete(input, cancellationToken);

        //    if (res.IsSuccess)
        //        return Ok(res.Value);
        //    else
        //        return BadRequest(res.Error.Message);

        //}

    }
}


