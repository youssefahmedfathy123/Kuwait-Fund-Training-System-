using System;

namespace Application.EntitiesOperations.Waiting;
    public record UpdateWaitingDto(
        Guid Id,
        string Name,
        string NationalId,
        DateTime Date
        );


