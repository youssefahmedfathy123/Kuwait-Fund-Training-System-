using Application;
using Application.EntitiesOperations.Withdrawal;
using Gatherly.Domain.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Presentation.Controllers.@base;

namespace Presentation.Controllers.Withdrawal
{
    public class WithdrawalController : ApiController
    {
        private readonly IWithdrawalServices _withdrawalServices;
        public WithdrawalController(IWithdrawalServices withdrawalServices)
        {
            _withdrawalServices = withdrawalServices;
        }
        [Authorize(Roles = "Trainee")]

        [HttpPost]
        public async Task<IActionResult> Create(CreateWithdrawalFileDto input, CancellationToken cancellationToken)
        {
            return Ok(await _withdrawalServices.Create(input, cancellationToken));
        }

        [Authorize(Roles = "Coordinator,Trainer")]
        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken = default)
        {
            return Ok(await _withdrawalServices.Read(cancellationToken));

        }

        //[HttpPut]
        //public async Task<Result<IActionResult>> Update(UpdateWithdrawalFileDto input, CancellationToken cancletionToken)
        //{
        //    var res = await _withdrawalServices.Update(input, cancletionToken);

        //    if (res.IsSuccess)
        //        return Ok(res.Value);
        //    else
        //        return BadRequest(res.Error.Message);

        //}


        //[HttpDelete]
        //public async Task<IActionResult> Delete([FromForm] DeleteTable input, CancellationToken cancellationToken = default)
        //{
        //    var res = await _withdrawalServices.Delete(input, cancellationToken);

        //    if (res.IsSuccess)
        //        return Ok(res.Value);
        //    else
        //        return BadRequest(res.Error.Message);


        //}


        [Authorize(Roles = "Coordinator")]
        [HttpPut]
        public async Task<Result<IActionResult>> ApproveOrReject(Guid WithdrawalId, LeaveStatus status, CancellationToken cancletionToken)
        {
            var res = await _withdrawalServices.ApproveOrReject(WithdrawalId,status, cancletionToken);

            if (res.IsSuccess)
                return Ok(res.Value);
            else
                return BadRequest(res.Error.Message);

        }

    }
}


