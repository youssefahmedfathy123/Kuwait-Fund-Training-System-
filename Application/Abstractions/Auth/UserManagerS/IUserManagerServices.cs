using Gatherly.Domain.Shared;
using System.Threading.Tasks;

namespace Application.Abstractions.Auth.UserManagerS
{
    public interface IUserManagerServices
    {
        Task<Result<string>> AddPermissionToUser(string username,string permission);
        Task<Result<string>> RemovePermissionFromUser(string username, string permission);
        Task<Result<string>> AddRoleToUser(string username, string rolename);
        Task<Result<string>> RemoveRoleFromUser(string username, string rolename);

    }

}



