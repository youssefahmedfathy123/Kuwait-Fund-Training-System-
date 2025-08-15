using Application.Abstractions.RoleUpgradeRequest;
using Domain.Entities;
using Domain.Entities.role;
using Gatherly.Domain.Shared;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services.RoleUpgradeRequests
{
    public sealed class RoleUpgradeRequestServices : IRoleUpgradeRequestServices
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public RoleUpgradeRequestServices(ApplicationDbContext context, 
            UserManager<User> userManager, 
            RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager; 
        }

        public async Task<Result<string>> Add(string userId, string RequestRole, CancellationToken Cancellation)
        {
            var User = await _userManager.FindByIdAsync(userId);
            if (User == null)
                return Result.Failure<string>(new Error("User","User not found"));


            var userExisted = await _context.RoleUpgradeRequests
                .FirstOrDefaultAsync(x => x.UserId == userId && x.RequestedRole.ToLower() == RequestRole.ToLower());

            if (userExisted is not null)
                return Result.Failure<string>(new Error("Request", "You already have a request for this role"));


            if (string.IsNullOrWhiteSpace(RequestRole))
                return Result.Failure<string>(new Error("Role", "Role cannot be empty"));

            var Role = await _roleManager.FindByNameAsync(RequestRole);

            if (Role == null)
                return Result.Failure<string>(new Error("Role", "Role not found"));

            var NewRequest = new RoleUpgradeRequest(
                userId,RequestRole
                );

            await _context.AddAsync(NewRequest);
            await _context.SaveChangesAsync(Cancellation);

            return Result.Success("Request is Added successfully!");
        }



        public async Task<Result<string>> ApproveOrReject(Guid RequestId, bool IsApproved, CancellationToken Cancellation)
        {
            var Request = await _context.RoleUpgradeRequests
                .FirstOrDefaultAsync(x => x.Id == RequestId);

            if (Request == null)
                return Result.Failure<string>(new Error("Request", "Request not found"));

            var User = await _userManager.FindByIdAsync(Request.UserId);

            if (IsApproved)
            {
                var user = await _userManager.FindByIdAsync(Request.UserId);
                if (user == null)
                    return Result.Failure<string>(new Error("User", "User not found"));

                var role = await _roleManager.FindByNameAsync(Request.RequestedRole);
                if (role == null)
                    return Result.Failure<string>(new Error("Role", "Role not found"));


                await _userManager.AddToRoleAsync(user, Request.RequestedRole);

                
                Request.Approve(User.Email,User.UserName,Request.RequestedRole);

            }
            else
                Request.Reject(User.Email, User.UserName, Request.RequestedRole);


            await _context.SaveChangesAsync(Cancellation);

            return Result.Success("Request has been processed successfully!");
        }

    }


}




