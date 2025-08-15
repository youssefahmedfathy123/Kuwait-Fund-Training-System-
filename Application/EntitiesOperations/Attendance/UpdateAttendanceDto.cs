using Domain.Enums;
using System;

namespace Application.EntitiesOperations.Attendance;

public record UpdateAttendanceDto(Guid Id,Guid TraineeId, Guid SchedualId, AttendanceStatus Status);




