using Microsoft.AspNetCore.Http;
using System;

namespace Application.EntitiesOperations.Leave;

public record UpdateLeaveDto(
    Guid Id, Guid TraineeId, byte[]? Pdf, KindOfLeave Kind, LeaveStatus Status, DateTime Start, int NumberOfDays
    );

public record UpdateLeaveFileDto(
    Guid Id, Guid TraineeId,IFormFile file, KindOfLeave Kind, LeaveStatus Status, DateTime Start, int NumberOfDays
    );


