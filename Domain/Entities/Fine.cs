using Domain.Primitives;

namespace Domain.Entities
{
    public class Fine : Aditable<Guid>
    {
        private Fine()
        {
            
        }

        public Fine(Guid traineeId, int value, string reason)
        {
            TraineeId = traineeId;
            Value = value;
            Reason = reason;
        }

        public Guid TraineeId { get;private set; }
        public Trainee Trainee { get;private set; }
        public int Value { get;private set; }
        public string Reason { get;private set; }


    }
}
