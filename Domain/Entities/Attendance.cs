using Domain.Enums;
using Domain.Primitives;

namespace Domain.Entities
{
    public sealed class Attendance : Aditable<Guid>
    {
        public Guid TraineeId { get; private set; }
        public Trainee Trainee { get;private set; }
        public Guid SchedualId { get;private set; }
        public Schedual Schedual { get;private set; }
        public AttendanceStatus Status { get; private set; }
        public DateTime Date { get;private set; }

        private Attendance() { }
        public Attendance(
            Guid traineeId,
            Guid schedualId,
            AttendanceStatus status , DateTime date)
        {
            TraineeId = traineeId;
            SchedualId = schedualId;
            Status = status;
            Date = date;
        }
    }
}



