using Microsoft.AspNetCore.Http;
using System;

namespace Application.EntitiesOperations.End_of_3phasesReport;
    public record CreateEnd_of_3phasesReportDto(
        Guid TraineeId ,
        byte[] Pdf 
        );


   public record CreateEnd_of_3phasesReportWithFileDto(
        Guid TraineeId,
        IFormFile Pdf
        );


