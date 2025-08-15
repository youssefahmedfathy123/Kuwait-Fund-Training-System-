using Microsoft.AspNetCore.Http;
using System;

namespace Application.EntitiesOperations.Excuses;

public record CreateExcusesDto(
Guid AttendanceId,
string UserId,
byte[] MedicalReport,
Aggrement Aggrement
);


public record CreateExcusesFileDto(
Guid AttendanceId,
string UserId,
IFormFile file,
Aggrement Aggrement
);


