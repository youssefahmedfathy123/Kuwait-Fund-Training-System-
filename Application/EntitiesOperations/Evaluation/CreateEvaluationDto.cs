using System;

namespace Application.EntitiesOperations.Evaluation;

public record CreateEvaluationDto(
     Guid TraineeId ,
     byte[] FileData ,
     decimal TrainerEvaluation,
     decimal ExamResult,
     decimal CoordinatorEvaluation ,
     decimal FinalScore 
    );


