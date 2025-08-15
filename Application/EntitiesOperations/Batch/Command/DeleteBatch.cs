using Application.Message;
using Gatherly.Domain.Shared;
using System;

namespace Application.EntitiesOperations.Batch.Command;

public sealed record DeleteBatch(Guid id)
    : ICommand<Result<string>>;


