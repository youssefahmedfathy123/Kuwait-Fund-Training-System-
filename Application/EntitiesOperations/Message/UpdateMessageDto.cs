using System;

namespace Application.EntitiesOperations.Message;

public record UpdateMessageDto(
    Guid Id,
    string SenderId,
    string ReceiverId,
    string Content,
    DateTime SentAt
    );    


