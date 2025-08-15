using Application;
using Application.EntitiesOperations.Attendance;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Presentation.Controllers.@base;

namespace Presentation.Controllers.Attendance
{
    [Authorize(Roles = "Coordinator")]
    public class AttendanceController : ApiController
    {
        private readonly IAttendanceServices _attendanceServices;
        public AttendanceController(IAttendanceServices attendanceServices)
        {
            _attendanceServices = attendanceServices;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CreateAttendanceDto input, CancellationToken cancellationToken = default)
        {

            return Ok(await _attendanceServices.Create(input, cancellationToken));

        }

        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken = default)
        {
            return Ok(await _attendanceServices.Read(cancellationToken));

        }

        [HttpPut]
        public async Task<IActionResult> Update([FromForm] UpdateAttendanceDto input, CancellationToken cancellationToken = default)
        {
            var res = await _attendanceServices.Update(input, cancellationToken);

            if (res.IsSuccess)
                return Ok(res.Value);
            else
                return BadRequest(res.Error.Message);

        }


        [HttpDelete]
        public async Task<IActionResult> Delete([FromForm] DeleteTable input, CancellationToken cancellationToken = default)
        {
            var res = await _attendanceServices.Delete(input, cancellationToken);

            if (res.IsSuccess)
                return Ok(res.Value);
            else
                return BadRequest(res.Error.Message);

        }



        [HttpGet("Check10percentageAttendance")]
        public async Task<IActionResult> Check10percentageAttendance(Guid courceId, CancellationToken cancellationToken)
        {
            return Ok(await _attendanceServices.Check10percentageAttendance(courceId,cancellationToken));
        }



    }
}
