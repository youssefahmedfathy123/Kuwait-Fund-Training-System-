using System;

namespace Application.EntitiesOperations.Feedback;

    public record UpdateFeedbackDto(
        Guid Id, 
        string UserId,
        Guid CourceId,
        string Opinion
        );


