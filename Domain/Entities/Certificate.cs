using Domain.Primitives;

namespace Domain.Entities
{
    public class Certificate : Aditable<Guid>
    {
        public Guid TraineeId { get;private set; }
        public Trainee Trainee { get;private set; }

        public byte[] Pdf { get;private set; }

        public CertificateStatus Status { get;private set; }

        private Certificate() { }
        public Certificate(Guid traineeId, byte[] pdf)
        {
            Status = CertificateStatus.Pending;
            TraineeId = traineeId;
            Pdf = pdf;
        }

        public void Deliver()
        {
            Status = CertificateStatus.Delevierd;
        }
    }
}


public enum CertificateStatus
{
    Delevierd,
    Pending
}