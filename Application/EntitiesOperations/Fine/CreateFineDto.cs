using System;

namespace Application.EntitiesOperations.Fine;

public record CreateFineDto(
         Guid TraineeId ,
         int Value ,
         string Reason
    );




