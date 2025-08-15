using Application.EntitiesOperations.Cource;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Presentation.Controllers.@base;

namespace Presentation.Controllers.Cource
{
    public class CourceController : ApiController
    {
        private readonly ICourceServices _courceServices;
        public CourceController(ICourceServices courcesServices)
        {
            _courceServices = courcesServices;
        }
        [Authorize(Roles = "Coordinator")]

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CreateCourceDto input, CancellationToken cancellationToken = default)
        {

            return Ok(await _courceServices.Create(input, cancellationToken));

        }


        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken = default)
        {
            return Ok(await _courceServices.Read(cancellationToken));

        }
        [Authorize(Roles = "Coordinator")]

        [HttpPut]
        public async Task<IActionResult> Update([FromForm] EditCourceDto input, CancellationToken cancellationToken = default)
        {
            var res = await _courceServices.Update(input, cancellationToken);

            if (res.IsSuccess)
                return Ok(res.Value);
            else
                return BadRequest(res.Error.Message);

        }

        [Authorize(Roles = "Coordinator")]

        [HttpDelete]
        public async Task<IActionResult> Delete([FromForm] DeleteCource input, CancellationToken cancellationToken = default)
        {
            var res = await _courceServices.Delete(input, cancellationToken);

            if (res.IsSuccess)
                return Ok(res.Value);
            else
                return BadRequest(res.Error.Message);

        }

    }
}


