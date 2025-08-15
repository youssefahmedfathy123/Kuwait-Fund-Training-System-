using Domain.Primitives;

namespace Domain.Entities
{
    public class Excuses : Aditable<Guid>
    {
        private Excuses() { }
        public Excuses(string userId, byte[] pdf,Guid attendanceId)
        {
            UserId = userId;
            MedicalReport = pdf;
            AttendanceId = attendanceId;
            Aggrement = Aggrement.Pending;
        }

        
        public Attendance Attendance { get;private set; }
        public Guid AttendanceId { get;private set; }
        
        public string UserId { get;private set; }
        public User User { get;private set; }



        public byte[] MedicalReport { get;private set; }



        public Aggrement Aggrement { get; private set; }
        public void Accepted()
        {
            Aggrement = Aggrement.Accepted;
        }
        public void NotAccepted()
        {
            Aggrement = Aggrement.NotAccepted;
        }

    }
}

public enum Aggrement
{
    Accepted , NotAccepted , Pending
}


