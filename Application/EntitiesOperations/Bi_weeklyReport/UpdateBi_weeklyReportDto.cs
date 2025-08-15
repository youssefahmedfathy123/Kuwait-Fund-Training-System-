using Microsoft.AspNetCore.Http;
using System;

namespace Application.EntitiesOperations.Bi_weeklyReport;
    public record UpdateBi_weeklyReportDto(
        Guid Id , string UserId, int WeekNumberOfPhase,
    DateTime StartDateOf2Weekes, byte[] Pdf
        );

    public record UpdateBi_weeklyReportFileDto(
          Guid Id, string UserId, int WeekNumberOfPhase,
      DateTime StartDateOf2Weekes, IFormFile file
          );



