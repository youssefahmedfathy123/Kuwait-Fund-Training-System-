using Domain.Enums;
using System;

namespace Application.EntitiesOperations.Attendance;

public record CreateAttendanceDto(Guid TraineeId, Guid SchedualId, AttendanceStatus Status);





