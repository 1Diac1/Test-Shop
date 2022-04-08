using Test_Shop.Shared.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Test_Shop.Domain.Entities;
using System.Threading.Tasks;
using System.Linq;

namespace Test_Shop.DataAccess.MsSql.Data
{
    public class ApplicationDbContextSeed
    {
        public static async Task SeedDefaultUserAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            var administratorRole = new IdentityRole("Administrator");

            if (roleManager.Roles.All(r => r.Name != administratorRole.Name))
                await roleManager.CreateAsync(administratorRole);

            var administrator = new ApplicationUser
            {
                UserName = "admin@mail.ru",
                Email = "admin@mail.ru"
            };

            if (userManager.Users.All(u => u.UserName != administrator.UserName))
            {
                await userManager.CreateAsync(administrator, "Administrator1!");
                await userManager.AddToRolesAsync(administrator, new[] {administratorRole.Name});
            }
        }

        public static async Task SeedSampleDataAsync(ApplicationDbContext context)
        {
            if (!context.Products.Any())
            {
                context.Products.AddRange(
                    new Product
                    {
                        Name = "iPhone 11",
                        Description = "Apple A13 Bionic",
                        Price = 64990
                    },
                    new Product
                    {
                        Name = "iPhone 11 Pro",
                        Description = "Apple A13 Bionic",
                        Price = 89990
                    },
                    new Product
                    {
                        Name = "iPhone 11 Pro Max",
                        Description = "Apple A13 Bionic",
                        Price = 94990
                    },
                    new Product
                    {
                        Name = "iPhone 12",
                        Description = "Apple A13 Bionic",
                        Price = 84990
                    },
                    new Product
                    {
                        Name = "iPhone 12 Pro",
                        Description = "Apple A13 Bionic",
                        Price = 95990
                    },
                    new Product
                    {
                        Name = "iPhone 11 Pro Max",
                        Description = "Apple A13 Bionic",
                        Price = 105990
                    },
                    new Product
                    {
                        Name = "iPhone 13",
                        Description = "Apple A13 Bionic",
                        Price = 89990
                    },
                    new Product
                    {
                        Name = "iPhone 12 Pro",
                        Description = "Apple A13 Bionic",
                        Price = 99990
                    },
                    new Product
                    {
                        Name = "iPhone 13 Pro Max",
                        Description = "Apple A13 Bionic",
                        Price = 109990
                    }
                );
            }

            await context.SaveChangesAsync();
        }
    }
}
