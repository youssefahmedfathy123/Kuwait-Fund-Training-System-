using System;

namespace Application.EntitiesOperations.Trainee;

public record EditTraineeDto(
          Guid Id, string Name, string UserId, Guid GroupId, Guid? CompanyId
   );


