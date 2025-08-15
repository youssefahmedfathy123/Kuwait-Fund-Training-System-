using Domain.Primitives;

namespace Domain.Entities
{
    public class Leave : Aditable<Guid>
    {
        private Leave() { }
        public Guid TraineeId { get;private set; }
        public Trainee Trainee { get; private set; }
        public byte[]? Pdf { get;private set; }
        public KindOfLeave Kind { get;private set; }
        public LeaveStatus Status { get;private set; }
        public DateTime Start { get;private set; }
        public int NumberOfDays { get;private set; }
        public void Approved()
        {
            Status = LeaveStatus.Approved;
        }
        public void Rejected()
        {
            Status = LeaveStatus.Rejected;
        }

        public Leave(Guid traineeId,int numberOfDays, DateTime start, KindOfLeave kind, byte[]? pdf = null)
        {
            Start = start;
            Kind = kind;
            NumberOfDays = numberOfDays;
            TraineeId = traineeId;
            Status = LeaveStatus.Pending;
            Pdf = pdf;
        }
    }
}
public enum KindOfLeave
{
    Sick , Normal 
}