using Domain.Enums;
using System;

namespace Application.EntitiesOperations.Attendance;

 public record AttendanceDto(Guid TraineeId, Guid SchedualId,AttendanceStatus Status);
    
        
        
        



