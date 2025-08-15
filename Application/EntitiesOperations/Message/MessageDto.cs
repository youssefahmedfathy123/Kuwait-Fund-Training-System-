using System;

namespace Application.EntitiesOperations.Message;

public record MessageDto(
    string SenderId,
    string ReceiverId,
    string Content,
    DateTime SentAt
    );


