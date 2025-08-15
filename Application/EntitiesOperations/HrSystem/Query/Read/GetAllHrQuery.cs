using Application.Message;
using System.Collections.Generic;

namespace Application.EntitiesOperations.HrSystem.Query.Read;

public record GetAllHrQuery() : IQuery<List<HrDto>>;
