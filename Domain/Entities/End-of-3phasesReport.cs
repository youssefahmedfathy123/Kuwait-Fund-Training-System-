using Domain.Primitives;

namespace Domain.Entities
{
    public class End_of_3phasesReport : Aditable<Guid>
    {
        private End_of_3phasesReport() { }

        public End_of_3phasesReport(Guid traineeId, byte[] pdf)
        {
            TraineeId = traineeId;
            Pdf = pdf;
        }

        public Guid TraineeId { get;private set; }
        public Trainee Trainee { get;private set; }
        public byte[] Pdf { get;private set; }


    }
}


