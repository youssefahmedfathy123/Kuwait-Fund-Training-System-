using Application.Message;

namespace Application.EntitiesOperations.Company.Query;
    public sealed record CompanyDto(
          string Name ,
          string About ,
          string? Phone1 ,
          string? Phone2 ,
          string Country ,
          string Manager
        ) : ICommand<string>;
   


