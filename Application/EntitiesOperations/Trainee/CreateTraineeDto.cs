using System;

namespace Application.EntitiesOperations.Trainee;
    public record CreateTraineeDto(
                 string Name, Guid GroupId,string UserId, Guid? CompanyId = null
        );





