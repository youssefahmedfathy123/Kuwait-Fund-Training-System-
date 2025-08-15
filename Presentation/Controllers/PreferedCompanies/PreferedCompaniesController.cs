using Application;
using Application.EntitiesOperations.PreferedCompanies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Presentation.Controllers.@base;

namespace Presentation.Controllers.PreferedCompanies
{
    public class PreferedCompaniesController : ApiController
    {
        private readonly IPreferedCompaniesServices _PreferedCompaniesServices;
        public PreferedCompaniesController(IPreferedCompaniesServices PreferedCompaniesServices)
        {
            _PreferedCompaniesServices =  PreferedCompaniesServices;
        }
        [Authorize(Roles = "Trainee")]

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CreatePreferedCompaniesDto input, CancellationToken cancellationToken = default)
        {

            return Ok(await _PreferedCompaniesServices.Create(input, cancellationToken));

        }
        [Authorize(Roles = "Coordinator,Trainer")]

        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken = default)
        {
            return Ok(await _PreferedCompaniesServices.Read(cancellationToken));

        }

        [HttpPut]
        public async Task<IActionResult> Update([FromForm] UpdatePreferedCompaniesDto input, CancellationToken cancellationToken = default)
        {
            var res = await _PreferedCompaniesServices.Update(input, cancellationToken);

            if (res.IsSuccess)
                return Ok(res.Value);
            else
                return BadRequest(res.Error.Message);

        }


        [HttpDelete]
        public async Task<IActionResult> Delete([FromForm] DeleteTable input, CancellationToken cancellationToken = default)
        {
            var res = await _PreferedCompaniesServices.Delete(input, cancellationToken);

            if (res.IsSuccess)
                return Ok(res.Value);
            else
                return BadRequest(res.Error.Message);

        }

    }
}


