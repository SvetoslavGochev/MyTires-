namespace МоитеГуми.Infrastructure.Extensions
{
    using Microsoft.AspNetCore.Builder;
    using System.Linq;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.EntityFrameworkCore;
    using МоитеГуми.Data;
    using МоитеГуми.Data.Models;
    using System;
    using Microsoft.AspNetCore.Identity;
    using System.Threading.Tasks;

    using static МоитеГуми.Areas.Admin.AdminConstants;

 
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder PreparateDatabase(this IApplicationBuilder app)
        {
            using var scopesScope = app.ApplicationServices.CreateScope();

            var services = scopesScope.ServiceProvider;

            MigrateDatabase(services);

            SeedCategories(services);
            SeedAdministrator(services);

            return app;
        }

        private static void MigrateDatabase(IServiceProvider services)
        {
            var data = services.GetRequiredService<ApplicationDbContext>();
            data.Database.Migrate();
        }

        private static void SeedCategories(IServiceProvider services)
        {
            var data = services.GetRequiredService<ApplicationDbContext>();

            if (data.Categories.Any())
            {
                return;
            }
            data.Categories.AddRange(new[]
            {
                new Category { Name = "Нови"},
                new Category { Name = "Втора Употреба"},

            });
            data.SaveChanges();
        }

        private static void SeedAdministrator(IServiceProvider services)
        {
            var userManager = services.GetRequiredService<UserManager<User>>();
            var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

            Task
                 .Run(async () =>
                 {
                     if (await roleManager.RoleExistsAsync(AdministratorRoleName))
                     {
                         return;
                     }
                     var role = new IdentityRole { Name = AdministratorRoleName };
                     await roleManager.CreateAsync(role);

                     const string adminEmail = "admin@crs.com";
                     const string adminPassword = "admin12";

                     var user = new User
                     {
                         Email = adminEmail,
                         UserName = adminEmail,
                         FullName = "Admin",
                     };

                     await userManager.CreateAsync(user, adminPassword);

                     await userManager.AddToRoleAsync(user, role.Name);
                 })
                 .GetAwaiter()
                 .GetResult();
        }
    }
}
