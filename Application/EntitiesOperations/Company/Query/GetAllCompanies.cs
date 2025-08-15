using Application.Message;
using System.Collections.Generic;

namespace Application.EntitiesOperations.Company.Query;

public record GetAllCompanies : ICommand<List<CompanyDto>>;


