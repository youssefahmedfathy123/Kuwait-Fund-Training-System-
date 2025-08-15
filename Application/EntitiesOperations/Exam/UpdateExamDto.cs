using System;

namespace Application.EntitiesOperations.Exam;

public record UpdateExamDto(
    Guid Id,
    Guid CourceId
  , Guid GroupId
  , DateTime Date
  , TimeSpan Start
  , TimeSpan End);



