using Domain.Primitives;

namespace Domain.Entities
{
    public class Bi_weeklyReport :Aditable<Guid>
    {
        public User User { get;private set; }
        public string UserId { get;private set; }
        public int WeekNumberOfPhase { get;private set; }
        public DateTime StartDateOf2Weekes { get;private set; }
        public byte[] Pdf { get;private set; }

        private Bi_weeklyReport()
        {
            
        }
        public Bi_weeklyReport(string userId, int weekNumberOfPhase, DateTime startDateOf2Weekes, byte[] pdf)
        {
            UserId = userId;
            WeekNumberOfPhase = weekNumberOfPhase;
            StartDateOf2Weekes = startDateOf2Weekes;
            Pdf = pdf;
        }



    }
}
