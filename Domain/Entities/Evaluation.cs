using Domain.Primitives;

namespace Domain.Entities
{
    public class Evaluation : Aditable<Guid>
    {
        public Guid TraineeId { get; private set; }
        public Trainee Trainee { get; private set; }

        public byte[] FileData { get; private set; }

        public decimal TrainerEvaluation { get; private set; } 
        public decimal ExamResult { get; private set; }  
        public decimal CoordinatorEvaluation { get; private set; } 

        public decimal FinalScore { get; private set; }
        

        public Evaluation(Guid traineeId,
            byte[] fileData,
            decimal trainerEvaluation = 0,
            decimal examResult = 0,
            decimal coordinatorEvaluation = 0)
        {
            FileData = fileData;
            TraineeId = traineeId;

            SetEvaluations(trainerEvaluation, examResult, coordinatorEvaluation);
        }
        public void AddOrEditEvaluation(Roles role,int value)
        {
            if (role == Roles.Coordinator)
                CoordinatorEvaluation = value;
            else if (role == Roles.Trainer)
                TrainerEvaluation = value;

            FinalScore = (TrainerEvaluation * 0.7m) +
            (ExamResult * 0.2m) +
            (CoordinatorEvaluation * 0.1m);
        }

        public void AddOrEditExamResult(int value)
        {
            ExamResult = value;

            FinalScore = (TrainerEvaluation * 0.7m) +
            (ExamResult * 0.2m) +
            (CoordinatorEvaluation * 0.1m);
        }


        private Evaluation()
        {
        }

        private void SetEvaluations(decimal trainerEvaluation, decimal examResult, decimal coordinatorEvaluation)
        {
            if (trainerEvaluation < 0 || trainerEvaluation > 100)
                throw new ArgumentException("Trainer evaluation must be between 0 and 100");

            if (examResult < 0 || examResult > 100)
                throw new ArgumentException("Exam result must be between 0 and 100");

            if (coordinatorEvaluation < 0 || coordinatorEvaluation > 100)
                throw new ArgumentException("Coordinator evaluation must be between 0 and 100");

            TrainerEvaluation = trainerEvaluation;
            ExamResult = examResult;
            CoordinatorEvaluation = coordinatorEvaluation;

            FinalScore = (TrainerEvaluation * 0.7m) +
            (ExamResult * 0.2m) +
            (CoordinatorEvaluation * 0.1m);
        }
    }
}


