using System;

namespace Application.EntitiesOperations.Message;

public record CreateMessageDto(
    string SenderId ,
    string ReceiverId ,
    string Content ,
    DateTime SentAt
    );



