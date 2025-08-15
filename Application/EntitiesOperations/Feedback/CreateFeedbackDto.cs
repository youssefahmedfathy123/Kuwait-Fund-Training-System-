using System;

namespace Application.EntitiesOperations.Feedback;

    public record CreateFeedbackDto(
        string UserId,
        Guid CourceId,
        string Opinion
        );



