using Domain.Primitives;

namespace Domain.Entities
{
    public class Waiting : Aditable<Guid>
    {
        private Waiting() { }
        public Waiting(string name, string nationalId, DateTime date)
        {
            Name = name;
            NationalId = nationalId;
            Date = date;
        }
        public string Name { get;private set; }
        public string NationalId { get;private set; }
        public DateTime Date { get;private set; }
    }
}





