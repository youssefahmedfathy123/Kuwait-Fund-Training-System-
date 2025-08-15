using Application.Message;

namespace Application.EntitiesOperations.Company.Command
{
    public sealed record CreateCompanyDto(
        string Name, string About,
        string? Phone1, string? Phone2,
         string Countrye, string Manager
        )
        : ICommand<string>;
}




