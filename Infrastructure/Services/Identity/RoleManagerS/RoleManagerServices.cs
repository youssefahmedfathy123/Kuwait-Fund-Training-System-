using Application.Abstractions.Auth.RoleManagerS;
using Gatherly.Domain.Shared;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace Infrastructure.Services.Identity.RoleManagerS
{
    public sealed class RoleManagerServices : IRoleManagerServices
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        public RoleManagerServices(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public async Task<Result<string>> AddPermissionToRole(string role, string permission)
        {
            var Therole = await _roleManager.FindByNameAsync(role);
            if (Therole == null)
                return Result.Failure<string>(new Error("Role", $"Role '{role}' not found."));




            if (!string.IsNullOrWhiteSpace(permission))
            {
            var AllClaims = await _roleManager.GetClaimsAsync(Therole);

            var permissionClaim =  AllClaims.FirstOrDefault(c => c.Type == "Permission" && c.Value == permission);

            if (permissionClaim is not null)
            {
                return Result.Failure<string>(new Error("Permission", $"Permission '{permission}' is found already in role '{role}'."));
            }

                await _roleManager.AddClaimAsync(Therole, new Claim("Permission", permission));
            }
            else
                return Result.Failure<string>(new Error("Permission", "Permission cannot be null or empty."));

            return Result.Success($"Permission '{permission}' added to role '{role}' successfully.");
        }





        public async Task<Result<string>> RemovePermissionFromRole(string role, string permission)
        {
            var Therole = await _roleManager.FindByNameAsync(role);
            if (Therole == null)
                return Result.Failure<string>(new Error("Role", $"Role '{role}' not found."));


            if (!string.IsNullOrWhiteSpace(permission))
            {
            var AllClaims = await _roleManager.GetClaimsAsync(Therole);

            var permissionClaim = AllClaims.FirstOrDefault(c => c.Type == "Permission" && c.Value == permission);

            if (permissionClaim is null)
            {
                return Result.Failure<string>(new Error("Permission", $"Permission '{permission}' not found in role '{role}'."));
            }

                await _roleManager.RemoveClaimAsync(Therole, new Claim("Permission", permission));
            }
            else
                return Result.Failure<string>(new Error("Permission", "Permission cannot be null or empty."));

            return Result.Success($"Permission '{permission}' removed from role '{role}' successfully.");
        }

    }

}





