using System;

namespace Application.EntitiesOperations.Trainer;

    public record CreateTrainerDto
    (
         string Name,
         string Email,
         Guid BatchId ,
         Guid? CompanyId
    );



