using Domain.Primitives;

namespace Domain.Entities
{
    public class Exam : Aditable<Guid>
    {
        public Guid CourceId { get;private set; }
        public Cource Cource { get;private set; }
        public Guid GroupId { get;private set; }
        public Group Group { get;private set; }
        public DateTime Date { get;private set; }
        public TimeSpan Start { get;private set; }
        public TimeSpan End { get;private set; }
        public Exam(Guid courceId, Guid groupId, DateTime date, TimeSpan start, TimeSpan end)
        {
            CourceId = courceId;
            GroupId = groupId;
            Date = date;
            Start = start;
            End = end;
        }
        private Exam() { }

    }
}



