using System;

namespace Application.EntitiesOperations.Exam;

public record CreateExamDto(
  Guid CourceId 
, Guid GroupId 
, DateTime Date 
, TimeSpan Start 
, TimeSpan End 
    );



