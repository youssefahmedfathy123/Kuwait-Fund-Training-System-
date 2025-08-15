using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Persistence.Seed
{
    public static class DefaultRoles
    {
        public static async Task SeedAsync(RoleManager<IdentityRole> roleManger)
        {
            if (!roleManger.Roles.Any())
            {
                await roleManger.CreateAsync(new IdentityRole(Roles.SuperAdmin.ToString()));
                await roleManger.CreateAsync(new IdentityRole(Roles.Admin.ToString()));
                await roleManger.CreateAsync(new IdentityRole(Roles.Trainer.ToString()));
                await roleManger.CreateAsync(new IdentityRole(Roles.Trainee.ToString()));
                await roleManger.CreateAsync(new IdentityRole(Roles.Manager.ToString()));

            }
        }

    }

}



