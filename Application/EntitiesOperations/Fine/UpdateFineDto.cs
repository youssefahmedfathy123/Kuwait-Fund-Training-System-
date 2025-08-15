using System;

namespace Application.EntitiesOperations.Fine;

public record UpdateFineDto(
    Guid Id,
     Guid TraineeId,
     int Value,
     string Reason
    );





