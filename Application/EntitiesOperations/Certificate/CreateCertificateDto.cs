using System;

namespace Application.EntitiesOperations.Certificate;
    public record CreateCertificateDto(
         Guid TraineeId,
         byte[] Pdf
         );





