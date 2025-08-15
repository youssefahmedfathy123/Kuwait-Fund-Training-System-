using Application;
using Application.EntitiesOperations.Leave;
using Gatherly.Domain.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Presentation.Controllers.@base;

namespace Presentation.Controllers.Leave
{
    public class LeaveController : ApiController
    {
        private readonly ILeaveServices _leaveServices;
        public LeaveController(ILeaveServices leaveServices)
        {
            _leaveServices = leaveServices;
        }
        [Authorize(Roles = "Trainee")]

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] LeavePropertiesWithoutPdf input, [FromForm] IFormFile file, CancellationToken cancellationToken = default)
        {

            return Ok(await _leaveServices.Create(file,input, cancellationToken));

        }
        [Authorize(Roles = "Coordinator,Trainer")]

        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken = default)
        {
            return Ok(await _leaveServices.Read(cancellationToken));

        }

        //[HttpPut]
        //public async Task<Result<IActionResult>> Update([FromForm]UpdateLeaveFileDto input, CancellationToken cancletionToken)
        //{
        //    var res = await _leaveServices.Update(input, cancletionToken);

        //    if (res.IsSuccess)
        //        return Ok(res.Value);
        //    else
        //        return BadRequest(res.Error.Message);

        //}


        //[HttpDelete]
        //public async Task<IActionResult> Delete([FromForm] DeleteTable input, CancellationToken cancellationToken = default)
        //{
        //    var res = await _leaveServices.Delete(input, cancellationToken);

        //    if (res.IsSuccess)
        //        return Ok(res.Value);
        //    else
        //        return BadRequest(res.Error.Message);

        //}


        [HttpPost]
        public async Task<IActionResult> Approve([FromForm] Guid LeaveId, LeaveStatus status, CancellationToken cancellationToken = default)
        {
            var res = await _leaveServices.Approve(LeaveId, status, cancellationToken);

            if (res.IsSuccess)
                return Ok(res.Value);
            else
                return BadRequest(res.Error.Message);

        }

        [Authorize(Roles = "Coordinator,Trainer")]
        [HttpGet("download/{id}")]
        public async Task<IActionResult> DownloadPdf(Guid id, CancellationToken cancellationToken)
        {
            var leave = await _leaveServices.FindById(id, cancellationToken);

            if (leave == null)
                return NotFound("Not found!");

            var contentType = "application/pdf";
            var fileName = $"MedicalReport_{id}.pdf";

            return File(leave.Pdf, contentType, fileName);
        }


    }
}

