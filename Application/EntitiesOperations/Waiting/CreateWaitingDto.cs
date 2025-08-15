using System;

namespace Application.EntitiesOperations.Waiting;

public record CreateWaitingDto(
    string Name ,
    string NationalId ,
    DateTime Date
    );


