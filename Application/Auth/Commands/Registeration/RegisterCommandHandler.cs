using Application.Abstractions.Auth;
using Application.Message;
using Gatherly.Domain.Shared;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Auth.Commands.Registeration
{
    public class RegisterCommandHandler : ICommandHandler<RegisterCommand,Result<string>>
    {
        private readonly IAuthServices _authService;

        public RegisterCommandHandler(IAuthServices authService)
        {
            _authService = authService;
        }
        public async Task<Result<string>> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            return await _authService.Register(request);

        }
    }
}




