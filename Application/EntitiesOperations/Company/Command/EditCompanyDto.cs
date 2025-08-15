using Application.Message;
using Gatherly.Domain.Shared;
using System;

namespace Application.EntitiesOperations.Company.Command;

public record EditCompanyDto(
        Guid Id,string Name, string About,
        string? Phone1, string? Phone2,
         string Countrye, string Manager) 
    : ICommand<Result<string>>;




