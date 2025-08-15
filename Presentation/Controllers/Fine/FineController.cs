using Application;
using Application.EntitiesOperations.Fine;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Presentation.Controllers.@base;

namespace Presentation.Controllers.Fine
{
    [Authorize(Roles = "Coordinator")]

    public class FineController : ApiController
    {
        private readonly IFineServices _fineServices;
        public FineController(IFineServices fineServices)
        {
            _fineServices = fineServices;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CreateFineDto input, CancellationToken cancellationToken = default)
        {

            return Ok(await _fineServices.Create(input, cancellationToken));

        }

        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken = default)
        {
            return Ok(await _fineServices.Read(cancellationToken));

        }

        [HttpPut]
        public async Task<IActionResult> Update([FromForm] UpdateFineDto input, CancellationToken cancellationToken = default)
        {
            var res = await _fineServices.Update(input, cancellationToken);

            if (res.IsSuccess)
                return Ok(res.Value);
            else
                return BadRequest(res.Error.Message);

        }


        [HttpDelete]
        public async Task<IActionResult> Delete([FromForm] DeleteTable input, CancellationToken cancellationToken = default)
        {
            var res = await _fineServices.Delete(input, cancellationToken);

            if (res.IsSuccess)
                return Ok(res.Value);
            else
                return BadRequest(res.Error.Message);

        }

    }
}
