using Domain.Enums;
using Domain.Primitives;

namespace Domain.Entities
{
    public class ExamStatus : Aditable<Guid>
    {
        public Guid ExamId { get;private set; }
        public Exam Exam { get;private set; }
        public Guid TraineeId { get; private set; }
        public Trainee Trainee { get;private set; }
        public AttendanceStatus Status { get;private set; }
        public int Grade { get;private set; }
        public string Evaluation { get;private set; }
        private ExamStatus() { }
        public ExamStatus(Guid examId, 
            Guid traineeId, 
            AttendanceStatus status ,
            int grade,
            string evaluation)
        {
            ExamId = examId;
            TraineeId = traineeId;
            Status = status;
            Grade = grade;
            Evaluation = evaluation;
        }
      

    }
}


