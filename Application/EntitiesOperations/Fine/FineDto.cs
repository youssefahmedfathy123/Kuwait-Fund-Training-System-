using System;

namespace Application.EntitiesOperations.Fine;

    public record FineDto(
         Guid TraineeId,
         int Value,
         string Reason
        );


