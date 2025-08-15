using System;

namespace Application.EntitiesOperations.Schedual;
    public record UpdateSchedualDto(
        Guid Id,
        Guid CourseId,
        Guid GroupId,
        DateTime Day,
        TimeSpan Start,
        TimeSpan End
        );


