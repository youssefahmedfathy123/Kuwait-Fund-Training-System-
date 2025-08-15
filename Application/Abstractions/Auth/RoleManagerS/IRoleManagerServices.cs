using Gatherly.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Abstractions.Auth.RoleManagerS
{
    public interface IRoleManagerServices
    {
        Task<Result<string>> AddPermissionToRole(string role,string permission);
        Task<Result<string>> RemovePermissionFromRole(string role,string permission);

    }
}


