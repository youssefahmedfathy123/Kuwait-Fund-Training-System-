using System;

namespace Application.EntitiesOperations.Schedual;

    public record CreateSchedualDto(
     Guid CourseId ,
     Guid GroupId  ,
     DateTime Day ,
     TimeSpan Start,
     TimeSpan End 
        );

    