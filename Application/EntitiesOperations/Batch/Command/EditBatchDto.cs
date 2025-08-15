using Application.Message;
using Gatherly.Domain.Shared;
using System;

namespace Application.EntitiesOperations.Batch.Command;

public record EditBatchDto(
        Guid Id, string Name , DateTime StartDate, DateTime EndDate , int Phase ,int Year
    ) 
    : ICommand<Result<string>>;




