using Application.Message;
using System;

namespace Application.EntitiesOperations.Group.Command;

public record CreateGroupDto(string Name, Guid BatchId) : ICommand<string>;




