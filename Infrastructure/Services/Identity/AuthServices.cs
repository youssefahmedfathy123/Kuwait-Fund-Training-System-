using Application.Abstractions.Auth;
using Application.Auth.Commands.Registeration;
using Application.Auth.Queries.LoginOperation;
using Domain.Entities;
using Gatherly.Domain.Shared;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Services.Identity
{
    public sealed class AuthServices : IAuthServices
    {
        private readonly UserManager<User> _userManager;
        private readonly IJwt _jwt;
        private readonly ApplicationDbContext _context;

        public AuthServices(UserManager<User> userManager, IJwt jwt, ApplicationDbContext context)
        {
            _userManager = userManager;
            _jwt = jwt;
            _context = context;
        }

        public async Task<Result<string>> Register(RegisterCommand input)
        {
            

            var emailResult = Domain.ValueObjects.Email.Create(input.Email);
            if (emailResult.IsFailure)
                return Result.Failure<string>(emailResult.Error);

            var NewUser = new User(
                input.Name,
                input.UserName,
                emailResult.Value.Value,input.role
            );

            var result = await _userManager.CreateAsync(NewUser, input.Password);

            if (!result.Succeeded)
            {
                var errorMessages = result.Errors.Select(e => e.Description);
                var error = string.Join(", ", errorMessages);

                return Result.Failure<string>(new Error("Register.Failed", error));
            }

            var AddToRole = await _userManager.AddToRoleAsync(NewUser, "Trainee");

            if (!AddToRole.Succeeded)
            {
                var errorMessages = AddToRole.Errors.Select(e => e.Description);
                var error = string.Join(", ", errorMessages);
                return Result.Failure<string>(new Error("Register.AddToRoleFailed", error));
            }

            var roles = await _userManager.GetRolesAsync(NewUser);
            var token = await _jwt.GenerateToken(roles.ToList(), NewUser.UserName, NewUser.Id);

            return Result.Success(token);
        }

        public async Task<Result<string>> Login(LoginCommand input)
        {
            var user = await _userManager.FindByEmailAsync(input.Email);

            if (user == null)
            {
                return Result.Failure<string>(new Error("Login.Failed", "Invalid email or password."));
            }

            var isPasswordValid = await _userManager.CheckPasswordAsync(user, input.Password);

            if (!isPasswordValid)
            {
                return Result.Failure<string>(new Error("Login.Failed", "Invalid email or password."));
            }

            var roles = await _userManager.GetRolesAsync(user);
            var token = await _jwt.GenerateToken(roles.ToList(), user.UserName, user.Id);

            return Result.Success(token);
        }
    }
}



