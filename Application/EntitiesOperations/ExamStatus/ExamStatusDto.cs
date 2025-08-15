using Domain.Enums;
using System;

namespace Application.EntitiesOperations.ExamStatus;

    public record ExamStatusDto(
       Guid ExamId,
       Guid TraineeId,
       AttendanceStatus Status,
       int Grade,
       string Evaluation
        );



