using Application.Abstractions.Auth;
using Application.Message;
using Gatherly.Domain.Shared;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Auth.Queries.LoginOperation
{
    public class LoginCommandHandler : IQueryHandler<LoginCommand, Result<string>>
    {
        private readonly IAuthServices _authServices;
        public LoginCommandHandler(IAuthServices authServices)
        {
            _authServices = authServices;
        }
        public async Task<Result<string>> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            return await _authServices.Login(request);
        }
    }
}



