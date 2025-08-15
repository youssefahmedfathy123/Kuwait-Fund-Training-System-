using Application.Message;
using System;

namespace Application.EntitiesOperations.Batch.Command
{
    public sealed record CreateBatchDto(
        string Name, DateTime StartDate,
        DateTime EndDate,Phase Phase ,int Year
        )
        : ICommand<string>;
}


