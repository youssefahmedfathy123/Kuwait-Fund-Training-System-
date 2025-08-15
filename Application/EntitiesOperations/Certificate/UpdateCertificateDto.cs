using Microsoft.AspNetCore.Http;
using System;

namespace Application.EntitiesOperations;
    public record UpdateCertificateDto(
        Guid Id, 
        Guid TraineeId,
        byte[] Pdf,
        CertificateStatus Status);


public record UpdateCertificateFileDto(
       Guid Id,
       Guid TraineeId,
       IFormFile file,
       CertificateStatus Status);


