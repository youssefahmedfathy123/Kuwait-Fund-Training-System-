using Application;
using Application.EntitiesOperations.Bi_weeklyReport;
using Gatherly.Domain.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Presentation.Controllers.@base;

namespace Presentation.Controllers.Bi_weeklyReport
{
    public class Bi_weeklyReportController : ApiController
    {

        private readonly IBi_weeklyReportServices _Bi_weeklyReportServices;
        public Bi_weeklyReportController(IBi_weeklyReportServices Bi_weeklyReport)
        {
            _Bi_weeklyReportServices = Bi_weeklyReport;
        }


        [Authorize(Roles = "Trainee")]
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CreateBi_weeklyReportDtoWithoutPdfAndUserIdDto input, CancellationToken cancletionToken)
        {
            return Ok(await _Bi_weeklyReportServices.Create(input, cancletionToken));
        }


        [Authorize(Roles = "Coordinator")]
        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken = default)
        {
            return Ok(await _Bi_weeklyReportServices.Read(cancellationToken));

        }


        [Authorize(Roles = "Coordinator")]
        [HttpGet("download/{id}")]
        public async Task<IActionResult> DownloadPdf(Guid id, CancellationToken cancellationToken)
        {
            var cer = await _Bi_weeklyReportServices.FindById(id, cancellationToken);

            if (cer == null)
                return NotFound("Not found!");

            var contentType = "application/pdf";
            var fileName = $"MedicalReport_{id}.pdf";

            return File(cer.Pdf, contentType, fileName);
        }



        //[HttpPut]
        //public async Task<Result<IActionResult>> Update(UpdateBi_weeklyReportFileDto input, CancellationToken cancletionToken)
        //{
        //    var res = await _Bi_weeklyReportServices.Update(input, cancletionToken);

        //    if (res.IsSuccess)
        //        return Ok(res.Value);
        //    else
        //        return BadRequest(res.Error.Message);

        //}


        //[HttpDelete]
        //public async Task<IActionResult> Delete([FromForm] DeleteTable input, CancellationToken cancellationToken = default)
        //{
        //    var res = await _Bi_weeklyReportServices.Delete(input, cancellationToken);

        //    if (res.IsSuccess)
        //        return Ok(res.Value);
        //    else
        //        return BadRequest(res.Error.Message);

        //}

    }
}
