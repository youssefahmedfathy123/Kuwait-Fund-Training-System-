using Application.Auth.Commands.Registeration;
using Application.Auth.Queries.LoginOperation;
using Gatherly.Domain.Shared;
using System.Threading.Tasks;

namespace Application.Abstractions.Auth
{
    public interface IAuthServices
    {
        Task<Result<string>> Register(RegisterCommand input);
        Task<Result<string>> Login(LoginCommand input);

    }
}




