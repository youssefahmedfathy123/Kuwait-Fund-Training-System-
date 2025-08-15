using Application.Message;
using System.Collections.Generic;

namespace Application.EntitiesOperations.Group.Query;

public record GetAllGroups() : ICommand<List<GroupDto>>;



