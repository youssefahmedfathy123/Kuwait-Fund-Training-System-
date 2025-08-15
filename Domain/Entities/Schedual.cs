using Domain.Primitives;

namespace Domain.Entities
{
    public class Schedual : Aditable<Guid>
    {
        public Guid CourseId { get;private set; }
        public Cource Cource { get;private set; }
        public Guid GroupId { get;private set; }
        public Group Group { get;private set; }
        public Days Day { get; private set; }
        public TimeSpan Start { get;private set; }
        public TimeSpan End { get;private set; }
        public int Credits { get;private set; }
        private Schedual() { }

        public Schedual(Guid courseId, Guid groupId, Days day, TimeSpan start, TimeSpan end,int cred)
        {
            CourseId = courseId;
            GroupId = groupId;
            Day = day;
            Start = start;
            End = end;
            Credits = cred;
        }



    }
}
public enum Days
{
    Sunday,
    Monday,
    Tuesday,
    Wednesday,
    Thursday,
    Friday,
    Saturday
}

