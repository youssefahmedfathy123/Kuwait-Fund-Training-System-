using Microsoft.AspNetCore.Identity;

namespace Domain.Entities
{
    public sealed class User : IdentityUser
    {
        public string Name { get; private set; }
        public Roles? Role { get;private set; }

        private User() { }

        public User(string name,string username,string email, Roles? role = null
            )
            
        {
            Name = name;
            UserName = username;
            Email = email;
            Role = role;
            EmailConfirmed = true;
        }

    }
}

public enum Roles
{
    Admin = 1,
    SuperAdmin,
    Coordinator,
    Trainer,
    Trainee,
    Manager

}



