using System;

namespace Application.EntitiesOperations.Evaluation;

public record UpdateEvaluationDto(
    Guid Id,
    Guid TraineeId,
    byte[] FileData,
    decimal TrainerEvaluation,
    decimal ExamResult,
    decimal CoordinatorEvaluation,
    decimal FinalScore
    );


