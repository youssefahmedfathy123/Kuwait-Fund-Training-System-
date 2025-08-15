using System;

namespace Application.EntitiesOperations.Waiting;

public record WaitingDto(
        string Name,
        string NationalId,
        DateTime Date
    );


