using Application.EntitiesOperations.Company.Command;
using Application.EntitiesOperations.Company.Query;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Presentation.Controllers.@base;

namespace Presentation.Controllers.Comapny
{
    [Authorize(Roles = "Coordinator")]

    internal class CompanyController : ApiController
    {
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CreateCompanyDto input, CancellationToken cancellationToken = default)
        {
            var res = await Sender.Send(input, cancellationToken);

            return Ok(new { Status = res });

        }


        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken = default)
        {
            return Ok(await Sender.Send(new GetAllCompanies(), cancellationToken));

        }

        [HttpPut]
        public async Task<IActionResult> Update([FromForm] EditCompanyDto input, CancellationToken cancellationToken = default)
        {
            var res = await Sender.Send(input, cancellationToken);

            if (res.IsSuccess)
                return Ok(res.Value);
            else
                return BadRequest(res.Error.Message);

        }


        [HttpDelete]
        public async Task<IActionResult> Delete([FromForm] DeleteCompany input, CancellationToken cancellationToken = default)
        {
            var res = await Sender.Send(input, cancellationToken);

            if (res.IsSuccess)
                return Ok(res.Value);
            else
                return BadRequest(res.Error.Message);

        }

    }
}
