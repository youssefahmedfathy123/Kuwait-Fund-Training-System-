using Domain.Primitives;

namespace Domain.Entities
{
    public sealed class Batch : Aditable<Guid>
    {
        public string Name { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }
        public Phase Phase { get; private set; }
        public int Year { get;private set; }

        public void ChangePhase(Phase phase)
        {
            Phase = phase;
        }

        private Batch() { }
        //Burgan or Raudhatain

        public Batch(string name,DateTime start,DateTime end,Phase phase,int year)
        {
            Name = name;
            StartDate = start;
            EndDate = end;
            Phase = phase;
            Year = year;

        }

    }

}
public enum Phase
{
    AcademicTrainingInKuwait,
    FieldTrainingAbroad,
    FieldTrainingInKuwait
}

