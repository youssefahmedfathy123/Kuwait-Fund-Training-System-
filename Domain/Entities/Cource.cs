using Domain.Primitives;

namespace Domain.Entities
{
    public sealed class Cource : Aditable<Guid>
    {

        private Cource() { }

        public string Name { get; private set; }
        public Guid TrainerId { get;private set; } 
        public Trainer Trainer { get;private set; }
        public int Credits { get;private set; }
        public Cource(string name, int cre,
            Guid trainerId)
        {
            Name = name;
            Credits = cre;
            TrainerId = trainerId;
        }

    }
    
}

