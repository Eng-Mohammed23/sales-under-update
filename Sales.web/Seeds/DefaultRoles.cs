namespace Sales.web.Seeds
{
    public static class DefaultRoles
    {
        public static async Task SeedAsync(RoleManager<IdentityRole> roleManager)
        {
            if (!roleManager.Roles.Any())
            {
                await roleManager.CreateAsync(new IdentityRole(AppRoles.Admin));
                await roleManager.CreateAsync(new IdentityRole(AppRoles.Archive));
                await roleManager.CreateAsync(new IdentityRole(AppRoles.FirstSales));
                await roleManager.CreateAsync(new IdentityRole(AppRoles.SecondSales));
                await roleManager.CreateAsync(new IdentityRole(AppRoles.FirstManager));
                await roleManager.CreateAsync(new IdentityRole(AppRoles.SecondManager));
            }
        }
    }
}
