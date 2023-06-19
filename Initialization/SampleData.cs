using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RezerwacjeSalAB.Data;
using RezerwacjeSalAB.Models;

namespace RezerwacjeSalAB.Initialization
{
    public class SampleData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            var context =
                new ApplicationDbContext(serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>());

            string[] roles = { "Administrator", "User" };


            foreach (string role in roles)
            {
                var roleStore = new RoleStore<IdentityRole>(context);

                if (!context.Roles.Any(r => r.Name == role))
                { 
                    roleStore.CreateAsync(new IdentityRole(role));
                }
            }

            // admin user credentials
            var user = new User()
            {
                FirstName = "admin",
                LastName = "admin",
                Email = "admin@gmail.com",
                NormalizedEmail = "ADMIN@GMAIL.COM",
                UserName = "admin@gmail.com",
                NormalizedUserName = "ADMIN@GMAIL.COM",
                EmailConfirmed = true,
                PhoneNumberConfirmed = false,
                SecurityStamp = Guid.NewGuid().ToString("D")
            };

            if (!context.Users.Any(u => u.UserName == user.UserName))
            {
                var password = new PasswordHasher<User>();
                var hashed = password.HashPassword(user, "secret");
                user.PasswordHash = hashed;

                var userStore = new UserStore<User>(context);
                userStore.CreateAsync(user);
            }

            var result = AssignRoles(serviceProvider, user.Email, roles);

            if (result.IsCompletedSuccessfully)
            {
                context.SaveChangesAsync();
            }
        }

        public static async Task<IdentityResult> AssignRoles(IServiceProvider services, string email, string[] roles)
        {
            UserManager<User> _userManager =
                services.GetService<UserManager<User>>();
            User user = await _userManager.FindByEmailAsync(email);
            var result = await _userManager.AddToRolesAsync(user, roles);

            return result;
        }
    }
}
