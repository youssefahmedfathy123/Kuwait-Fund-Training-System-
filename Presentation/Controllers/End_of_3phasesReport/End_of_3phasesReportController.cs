using Application;
using Application.EntitiesOperations.End_of_3phasesReport;
using Gatherly.Domain.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Presentation.Controllers.@base;

namespace Presentation.Controllers.End_of_3phasesReport
{

    public class End_of_3phasesReportController : ApiController
    {
        private readonly IEnd_of_3phasesReportServices _End_of_3phasesReport;
        public End_of_3phasesReportController(IEnd_of_3phasesReportServices End_of_3phasesReport)
        {
            _End_of_3phasesReport = End_of_3phasesReport;
        }
        [Authorize(Roles = "Coordinator,Trainer")]

        [HttpPost]
        public async Task<IActionResult> Create(CreateEnd_of_3phasesReportWithFileDto input, CancellationToken cancletionToken)
        {
            return Ok(await _End_of_3phasesReport.Create(input, cancletionToken));
        }

        [Authorize(Roles = "Coordinator,Trainer")]

        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken = default)
        {
            return Ok(await _End_of_3phasesReport.Read(cancellationToken));

        }
        [Authorize(Roles = "Coordinator,Trainer")]

        [HttpPut]
        public async Task<Result<IActionResult>> Update(UpdateEnd_of_3phasesReporFiletDto input, CancellationToken cancletionToken)
        {
            var res = await _End_of_3phasesReport.Update(input, cancletionToken);

            if (res.IsSuccess)
                return Ok(res.Value);
            else
                return BadRequest(res.Error.Message);

        }


        [Authorize(Roles = "Trainee")]
        [HttpGet("download/{id}")]
        public async Task<IActionResult> DownloadPdf(Guid id, CancellationToken cancellationToken)
        {
            var cer = await _End_of_3phasesReport.FindById(id, cancellationToken);

            if (cer == null)
                return NotFound("Not found!");

            var contentType = "application/pdf";
            var fileName = $"MedicalReport_{id}.pdf";

            return File(cer.Pdf, contentType, fileName);
        }


        [Authorize(Roles = "Coordinator,Trainer")]

        [HttpDelete]
        public async Task<IActionResult> Delete([FromForm] DeleteTable input, CancellationToken cancellationToken = default)
        {
            var res = await _End_of_3phasesReport.Delete(input, cancellationToken);

            if (res.IsSuccess)
                return Ok(res.Value);
            else
                return BadRequest(res.Error.Message);

        }

    }
}


