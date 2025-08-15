using Microsoft.AspNetCore.Http;
using System;

namespace Application.EntitiesOperations.End_of_3phasesReport;

public record UpdateEnd_of_3phasesReportDto(
      Guid Id , Guid TraineeId,
        byte[] Pdf
    );

public record UpdateEnd_of_3phasesReporFiletDto(
      Guid Id, Guid TraineeId,
       IFormFile file
    );



