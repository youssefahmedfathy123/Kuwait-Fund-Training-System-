using System;

namespace Application.EntitiesOperations.Leave;

public record CreateLeaveDto(
       Guid TraineeId, byte[]? Pdf , KindOfLeave Kind, LeaveStatus Status , DateTime Start , int NumberOfDays
    );


public record LeavePropertiesWithoutPdf(
           Guid TraineeId, KindOfLeave Kind, LeaveStatus Status, DateTime Start, int NumberOfDays
    );



