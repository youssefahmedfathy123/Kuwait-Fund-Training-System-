using System;

namespace Application.EntitiesOperations.Cource;
    public record CreateCourceDto(
         string Name, Guid TrainerId, int Credits
        );
    
