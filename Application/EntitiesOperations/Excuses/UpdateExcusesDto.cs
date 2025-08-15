using Microsoft.AspNetCore.Http;
using System;

namespace Application.EntitiesOperations.Excuses;

public record UpdateExcusesDto(
    Guid Id,
    Guid AttendanceId,
    string UserId,
    byte[] MedicalReport,
    Aggrement Aggrement
    );

public record UpdateExcusesFileDto(
    Guid Id,
    Guid AttendanceId,
    IFormFile file,
    Aggrement Aggrement
    );

