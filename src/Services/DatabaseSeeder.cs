using Microsoft.AspNetCore.Identity;
using NextTime.Constants;
using NextTime.Entities;
using NextTime.Exceptions;

namespace NextTime.Services;

public sealed class DatabaseSeeder(RoleManager<ApplicationRole> roleManager)
{
    public async Task SeedAllAsync()
    {
        await SeedRolesAsync();
    }

    private async Task SeedRolesAsync()
    {
        await CreateRoleAsync(RoleNames.User);
        await CreateRoleAsync(RoleNames.Admin);
    }

    private async Task CreateRoleAsync(string name)
    {
        if (!await roleManager.RoleExistsAsync(name))
        {
            var role = new ApplicationRole(name);
            var result = await roleManager.CreateAsync(role);

            if (!result.Succeeded)
            {
                throw new IdentityException(result);
            }
        }
    }
}
