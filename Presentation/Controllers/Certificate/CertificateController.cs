using Application;
using Application.EntitiesOperations;
using Gatherly.Domain.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Presentation.Controllers.@base;

namespace Presentation.Controllers.Certificate
{
    public class CertificateController : ApiController
    {
        private readonly ICertificateServices _CertificateServices;
       
        public CertificateController(ICertificateServices traineeServices)
        {
            _CertificateServices = traineeServices;
        }

        [Authorize(Roles = "Coordinator")]
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] Guid TraineeId, [FromForm] IFormFile File, CancellationToken cancellationToken = default)
        {

            return Ok(await _CertificateServices.Create(TraineeId,File, cancellationToken));

        }
        [Authorize(Roles = "Coordinator")]

        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken = default)
        {
            return Ok(await _CertificateServices.Read(cancellationToken));

        }
        [Authorize(Roles = "Coordinator")]

        [HttpPut]
        public async Task<Result<IActionResult>> Update([FromForm]UpdateCertificateFileDto input, CancellationToken cancletionToken)
        {
            var res = await _CertificateServices.Update(input, cancletionToken);

            if (res.IsSuccess)
                return Ok(res.Value);
            else
                return BadRequest(res.Error.Message);

        }

        [Authorize(Roles = "Trainee")]
        [HttpGet("download/{id}")]
        public async Task<IActionResult> DownloadPdf(Guid id, CancellationToken cancellationToken)
        {
            var cer = await _CertificateServices.FindById(id, cancellationToken);

            if (cer == null)
                return NotFound("Not found!");

            var contentType = "application/pdf";
            var fileName = $"MedicalReport_{id}.pdf";

            return File(cer.Pdf, contentType, fileName);
        }




        [Authorize(Roles = "Coordinator")]
        [HttpDelete]
        public async Task<IActionResult> Delete([FromForm] DeleteTable input, CancellationToken cancellationToken = default)
        {
            var res = await _CertificateServices.Delete(input, cancellationToken);

            if (res.IsSuccess)
                return Ok(res.Value);
            else
                return BadRequest(res.Error.Message);

        }

    }
}
