using System;

namespace Application.EntitiesOperations.Bi_weeklyReport;

public record Bi_weeklyReportDto(string UserId, int WeekNumberOfPhase, 
    DateTime StartDateOf2Weekes,byte[] Pdf);



