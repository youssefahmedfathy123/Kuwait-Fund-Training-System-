using System;

namespace Application.EntitiesOperations.Exam;

public record ExamDto(Guid CourceId
, Guid GroupId
, DateTime Date
, TimeSpan Start
, TimeSpan End);


