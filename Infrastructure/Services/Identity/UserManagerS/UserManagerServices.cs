using Application.Abstractions.Auth.UserManagerS;
using Domain.Entities;
using Gatherly.Domain.Shared;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace Infrastructure.Services.Identity.UserManagerS
{
    public class UserManagerServices : IUserManagerServices
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<User> _userManager;

        public UserManagerServices(RoleManager<IdentityRole> roleManager, UserManager<User> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }


        public async Task<Result<string>> AddPermissionToUser(string username, string permission)
        {
            var User = await _userManager.FindByNameAsync(username);
            if (User == null)
                return Result.Failure<string>(new Error("UserName", "User name is not found!"));


            if (!string.IsNullOrWhiteSpace(permission))
            {
                var AllClaims = await _userManager.GetClaimsAsync(User);

                var permissionClaim = AllClaims.FirstOrDefault(c => c.Type == "Permission" && c.Value == permission);

                if (permissionClaim is not null)
                {
                    return Result.Failure<string>(new Error("Permission", $"Permission '{permission}' is set already to user '{username}'."));
                }


                await _userManager.AddClaimAsync(User, new Claim("Permission", permission));
            }

            else
                return Result.Failure<string>(new Error("Permission", "Permission cannot be null or empty."));



            return Result.Success($"Permission '{permission}' is added to User '{username}' successfully.");

        }


        public async Task<Result<string>> RemovePermissionFromUser(string username, string permission)
        {
            var User = await _userManager.FindByNameAsync(username);
            if (User == null)
                return Result.Failure<string>(new Error("UserName", "User name is not found!"));


            if (!string.IsNullOrWhiteSpace(permission))
            {
                var AllClaims = await _userManager.GetClaimsAsync(User);

                var permissionClaim = AllClaims.FirstOrDefault(c => c.Type == "Permission" && c.Value == permission);

                if (permissionClaim is null)
                {
                    return Result.Failure<string>(new Error("Permission", $"Permission '{permission}' of user {username} is not found."));
                }


                await _userManager.RemoveClaimAsync(User, new Claim("Permission", permission));
            }

            else
                return Result.Failure<string>(new Error("Permission", "Permission cannot be null or empty."));



            return Result.Success($"Permission '{permission}' is removed to User '{username}' successfully.");

        }


        public async Task<Result<string>> AddRoleToUser(string username, string rolename)
        {
            var User = await _userManager.FindByNameAsync(username);
            if (User == null)
                return Result.Failure<string>(new Error("UserName", "User name is not found!"));


            if (!string.IsNullOrWhiteSpace(rolename))
            {
                var AllRoles = await _userManager.GetRolesAsync(User);

                var permissionClaim = AllRoles.FirstOrDefault(c => c == rolename);

                if (permissionClaim is not null)
                {
                    return Result.Failure<string>(new Error("Role", $"Role '{rolename}' is set already to user '{username}'."));
                }


                await _userManager.AddToRoleAsync(User, rolename);
            }

            else
                return Result.Failure<string>(new Error("Role", "Role name cannot be null or empty."));



            return Result.Success($"Role '{rolename}' is added to User '{username}' successfully.");

        }


        public async Task<Result<string>> RemoveRoleFromUser(string username, string rolename)
        {
            var User = await _userManager.FindByNameAsync(username);
            if (User == null)
                return Result.Failure<string>(new Error("UserName", "User name is not found!"));


            if (!string.IsNullOrWhiteSpace(rolename))
            {
                var AllRoles = await _userManager.GetRolesAsync(User);

                var permissionClaim = AllRoles.FirstOrDefault(c => c == rolename);

                if (permissionClaim is null)
                {
                    return Result.Failure<string>(new Error("Role", $"Role '{rolename}' of user {username} is not found."));
                }


                await _userManager.RemoveFromRoleAsync(User, rolename);
            }

            else
                return Result.Failure<string>(new Error("Role", "Role name cannot be null or empty."));


            return Result.Success($"Role '{rolename}' is removed from User '{username}' successfully.");

        }
    }

}



