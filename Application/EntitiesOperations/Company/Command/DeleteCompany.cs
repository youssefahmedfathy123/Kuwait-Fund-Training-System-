using Application.Message;
using Gatherly.Domain.Shared;
using System;

namespace Application.EntitiesOperations.Company.Command;

public sealed record DeleteCompany(Guid Id)
    : ICommand<Result<string>>;




