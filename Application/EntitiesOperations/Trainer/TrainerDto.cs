using System;

namespace Application.EntitiesOperations.Trainer;
    public record TrainerDto(
         string Name,
         string Email,
         Guid BatchId,
         Guid? CompanyId
        );
   

