namespace Sales.web.Seeds
{
    public static class DefaultUsers
    {
        public static async Task SeedAdminUserAsync(UserManager<ApplicationUser> userManager)
        {
            var users = new[]
            {
                new { FullName = "FirstAdmin", UserName = "admin", Email = "", Password = "", Role = AppRoles.Admin },
                new { FullName = "FirstManager", UserName = "manager", Email = "", Password = "", Role = AppRoles.FirstManager },
                new { FullName = "Salesperson", UserName = "salesperson", Email = "", Password = "", Role = AppRoles.FirstSales },
                new { FullName = "SecondManager", UserName = "manager", Email = "", Password = "", Role = AppRoles.SecondManager },
                new { FullName = "SecondSales", UserName = "salesperson", Email = "", Password = "", Role = AppRoles.SecondSales }
            };

            foreach (var u in users)
            {
                var user = await userManager.FindByEmailAsync(u.Email);
                if (user is null)
                {
                    var appUser = new ApplicationUser { FullName = u.FullName, UserName = u.UserName, Email = u.Email, EmailConfirmed = true };
                    await userManager.CreateAsync(appUser, u.Password);
                    await userManager.AddToRoleAsync(appUser, u.Role);
                }
            }

        }
    }
}
