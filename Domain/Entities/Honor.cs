using Domain.Primitives;

namespace Domain.Entities
{
    public class Honor : Aditable<Guid>
    {
        private Honor()
        {
            
        }

        public Honor(Guid traineeId)
        {
            TraineeId = traineeId;
        }

        public Guid TraineeId { get;private set; }
        public Trainee Trainee { get;private set; }


    }
}


