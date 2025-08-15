using Gatherly.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.EntitiesOperations.Attendance
{
    public interface IAttendanceServices 
    {
        Task<string> Create(CreateAttendanceDto input, CancellationToken cancletionToken);
        Task<Result<string>> Update(UpdateAttendanceDto input, CancellationToken cancletionToken);
        Task<Result<Guid>> Delete(DeleteTable input, CancellationToken cancletionToken);
        Task<List<AttendanceDto>> Read(CancellationToken cancletionToken);
        Task<string> Check10percentageAttendance(Guid courceId, CancellationToken cancellationToken);

    }
}




