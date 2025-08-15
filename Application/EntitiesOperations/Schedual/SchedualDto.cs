using System;

namespace Application.EntitiesOperations.Schedual;

public record SchedualDto(
    Guid CourseId,
    Guid GroupId,
    DateTime Day,
    TimeSpan Start,
    TimeSpan End
    );



