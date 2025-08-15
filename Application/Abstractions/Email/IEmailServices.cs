using System.Threading.Tasks;
using System.Threading;
using Domain.Entities.role;

namespace Application.Abstractions.Email
{
    namespace Application.Abstractions.Email
    {
        public interface IEmailServices
        {
            Task SendRoleUpgradeStatusEmailAsync(string email,
                string userName, string requestedRole,
                RoleUpgradeRequestStatus status, CancellationToken cancellationToken);
        }
    }
}


