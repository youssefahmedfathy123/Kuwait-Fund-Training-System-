using System;

namespace Application.EntitiesOperations.Evaluation;
    public class EvaluationDto(
     Guid TraineeId,
     byte[] FileData,
     decimal TrainerEvaluation,
     decimal ExamResult,
     decimal CoordinatorEvaluation,
     decimal FinalScore);



