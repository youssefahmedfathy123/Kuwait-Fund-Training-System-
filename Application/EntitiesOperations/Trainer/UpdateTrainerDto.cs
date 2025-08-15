using System;

namespace Application.EntitiesOperations.Trainer;

    public record UpdateTrainerDto(
         Guid Id,
         string Name,
         string Email,
         Guid BatchId ,
         Guid? CompanyId 
        );



