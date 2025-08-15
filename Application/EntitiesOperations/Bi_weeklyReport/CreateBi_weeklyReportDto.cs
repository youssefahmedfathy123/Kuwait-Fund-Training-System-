using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using System;

namespace Application.EntitiesOperations.Bi_weeklyReport;

    public record CreateBi_weeklyReportDto(string UserId, int WeekNumberOfPhase,
    DateTime StartDateOf2Weekes, byte[] Pdf);

public record CreateBi_weeklyReportDtoWithoutPdfAndUserIdDto(int WeekNumberOfPhase,
DateTime StartDateOf2Weekes , IFormFile file);



