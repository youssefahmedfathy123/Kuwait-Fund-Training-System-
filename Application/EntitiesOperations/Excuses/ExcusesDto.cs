using System;

namespace Application.EntitiesOperations.Excuses;

public record ExcusesDto(
 Guid AttendanceId ,
 string UserId ,
 byte[] MedicalReport ,
 Aggrement Aggrement );



