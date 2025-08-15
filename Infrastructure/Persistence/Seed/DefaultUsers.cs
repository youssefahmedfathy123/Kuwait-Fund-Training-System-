using Domain.Entities;
using Infrastructure.Persistence.Seed.Const;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Seed
{
    public static class DefaultUsers
    {
        public static async Task SeedBasicUserAsync(UserManager<User> userManager)
        {
            //var defaultUser = new User("defaultUser", "basicuserer@gmail.com", "Basicuser@gmail.com");

            //var user = await userManager.FindByEmailAsync(defaultUser.Email);

            //if (user == null)
            //{

            //    await userManager.CreateAsync(defaultUser, "P@ssword123");
            //    await userManager.AddToRoleAsync(defaultUser, Roles.Trainee.ToString());
            //}
        }


        public static async Task SeedSuperAdminAsync(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            var Super = new User("IamAnAdmin", "superadmin@gmail.com", "superadmin@gmail.com");

            var user = await userManager.FindByEmailAsync(Super.Email);
            if (user == null)
            {
                await userManager.CreateAsync(Super, "P@ssword123");
                await userManager.AddToRolesAsync(Super, new List<string> {
                    Roles.Admin.ToString(),
                    Roles.SuperAdmin.ToString(),
                    Roles.Trainee.ToString(),
                    Roles.Trainer.ToString(),
                    Roles.Manager.ToString()
                });

                var adminRole = await roleManager.FindByNameAsync(Roles.SuperAdmin.ToString());
                await roleManager.AddPermissionClaims(adminRole, "Cource");
            }
        }


        public static async Task AddPermissionClaims(this RoleManager<IdentityRole> roleManager, IdentityRole role, string module)
        {
            var allClaims = await roleManager.GetClaimsAsync(role);
            var allPermissions = Permissions.GeneratePermissionsList(module);

            foreach (var permission in allPermissions)
            {
                if (!allClaims.Any(c => c.Type == "Permission" && c.Value == permission))
                    await roleManager.AddClaimAsync(role, new Claim("Permission", permission));
            }

        }

    }


}
