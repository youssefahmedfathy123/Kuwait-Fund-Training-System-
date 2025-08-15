using Domain.Enums;
using Domain.Primitives;

namespace Domain.Entities
{
    public class Withdrawal : Aditable<Guid>
    {
        public string UserId { get;private  set; }
        public User User { get;private set; }
        public Reason Reason { get;private set; }
        public byte[]? MedicalReport { get; private set; }
        public LeaveStatus Status { get;private set; }
        public DateTime At { get;private set; }
        public DateTime Start { get;private set; }
        public DateTime? End { get;private set; }

        private Withdrawal() { }

        public Withdrawal(DateTime at,string userId, Reason reason,DateTime start,DateTime? end =null,byte[]? medicalReport = null)
        {
            At = DateTime.UtcNow;
            UserId = userId;
            Reason = reason;
            MedicalReport = medicalReport;
            Status = LeaveStatus.Pending;
            Start = start;
            End = end;
        }

        public void Approve()
        {
            Status = LeaveStatus.Approved;
        }

        public void Reject()
        {
            Status = LeaveStatus.Rejected;
        }

    }
}
public enum LeaveStatus { 
    Approved,
    Rejected,
    Pending
}




