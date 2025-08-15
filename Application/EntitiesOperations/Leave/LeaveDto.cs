using System;

namespace Application.EntitiesOperations.Leave;

public record LeaveDto(
         Guid TraineeId, byte[]? Pdf, KindOfLeave Kind, LeaveStatus Status, DateTime Start, int NumberOfDays
    );


