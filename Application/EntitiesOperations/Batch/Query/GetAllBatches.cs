using Application.Message;
using System.Collections.Generic;

namespace Application.EntitiesOperations.Batch.Query;

public record GetAllBatches : ICommand<List<BatchDto>>;


