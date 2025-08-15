using System;

namespace Application.EntitiesOperations.Cource;

public record EditCourceDto(
    Guid Id, string Name, Guid TrainerId, int Credits
    );

