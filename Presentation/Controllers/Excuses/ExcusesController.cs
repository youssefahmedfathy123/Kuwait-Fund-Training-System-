using Application;
using Application.EntitiesOperations.Excuses;
using Application.EntitiesOperations.Withdrawal;
using Gatherly.Domain.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Presentation.Controllers.@base;
using System.Security.Claims;

namespace Presentation.Controllers.Excuses
{
    public class ExcusesController : ApiController
    {
        private readonly IExcusesServices _excusesServices;
        public ExcusesController(IExcusesServices excusesServices)
        {
            _excusesServices = excusesServices;
        }
        [Authorize(Roles = "Trainee")]

        [HttpPost]
        public async Task<IActionResult> Create(CreateExcusesFileDto input, CancellationToken cancletionToken)
        {

            return Ok(await _excusesServices.Create(input, cancletionToken));

        }
        [Authorize(Roles = "Coordinator,Trainer")]

        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken = default)
        {
            return Ok(await _excusesServices.Read(cancellationToken));

        }


        //[HttpPut]
        //public async Task<Result<IActionResult>> Update(UpdateExcusesFileDto input, CancellationToken cancletionToken)
        //{
        //    var res = await _excusesServices.Update(input, cancletionToken);

        //    if (res.IsSuccess)
        //        return Ok(res.Value);
        //    else
        //        return BadRequest(res.Error.Message);

        //}


        //[HttpDelete]
        //public async Task<IActionResult> Delete([FromForm] DeleteTable input, CancellationToken cancellationToken = default)
        //{
        //    var res = await _excusesServices.Delete(input, cancellationToken);

        //    if (res.IsSuccess)
        //        return Ok(res.Value);
        //    else
        //        return BadRequest(res.Error.Message);

        //}


        [Authorize(Roles = "Coordinator,Trainer")]

        [HttpPut]
        public async Task<Result<IActionResult>> ApproveOrReject(Guid ExcusesId, Aggrement status, CancellationToken cancletionToken)
        {
            var res = await _excusesServices.ApproveOrReject(ExcusesId, status, cancletionToken);

            if (res.IsSuccess)
                return Ok(res.Value);
            else
                return BadRequest(res.Error.Message);

        }


    }
}

