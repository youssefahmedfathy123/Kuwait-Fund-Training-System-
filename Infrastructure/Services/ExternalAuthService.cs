using Application.Abstractions.Auth;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace Infrastructure.Services.Identity
{
    public class ExternalAuthService : IExternalAuthService
    {
        private readonly UserManager<User> _userManager;
        private readonly IJwt _jwt;
        private readonly RoleManager<IdentityRole> _roleManager;

        public ExternalAuthService(UserManager<User> userManager, IJwt jwt, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _jwt = jwt;
            _roleManager = roleManager;
        }

        //public async Task<string> HandleExternalLoginAsync(string email, string name)
        //{
        //    var user = await _userManager.FindByEmailAsync(email);

        //    if (user == null)
        //    {
        //        user = new User(name, email, email); // username = email
        //        await _userManager.CreateAsync(user);
        //        await _userManager.AddToRoleAsync(user, "Trainee"); 
        //    }

        //    var roles = await _userManager.GetRolesAsync(user);

        //    return await _jwt.GenerateToken(roles.ToList(), user.UserName, user.Id);
        //}
    }
}


