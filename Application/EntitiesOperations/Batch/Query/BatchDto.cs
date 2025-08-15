using Application.Message;
using System;

namespace Application.EntitiesOperations.Batch.Query;
    public sealed record BatchDto(
         string Name ,
         DateTime StartDate ,
         DateTime EndDate ,
         int Phase ,
         int Year
        ) : ICommand<string>;
   



