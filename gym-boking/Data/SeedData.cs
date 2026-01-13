using gym_boking.Models;
using Microsoft.AspNetCore.Identity;

namespace gym_boking.Data;

public class SeedData
{
    private static ApplicationDbContext _context = default!;
    private static RoleManager<IdentityRole> _roleManager = default!;
    private static UserManager<ApplicationUser> _userManager = default!;

    public static async Task Init(ApplicationDbContext context, IServiceProvider services)
    {
        _context = context;

        if (_context.Roles.Any()) return;

        _roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
        _userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
        var roleNames = new[] { "User", "Admin" };

        var adminEmail = "admin@admin.com";
        var userEmail = "user@user.com";

        await AddRolesAsync(roleNames);

        var admin = await AddAccountAsync(adminEmail, "P@55w.rd!");
        var user = await AddAccountAsync(userEmail, "Pa55w.rd!");

        await AddUserToRoleAsync(admin, "Admin");
        await AddUserToRoleAsync(user, "User");
    }

    private static async Task AddUserToRoleAsync(ApplicationUser user, string role)
    {
        if(!await _userManager.IsInRoleAsync(user, role))
        {
            var result = await _userManager.AddToRoleAsync(user, role);
            if (!result.Succeeded) throw new Exception(string.Join("\n", result.Errors));
        }
    }

    private static async Task AddRolesAsync(string[] roleNames)
    {
        foreach (var roleName in roleNames) 
        {
            if(await _roleManager.RoleExistsAsync(roleName)) continue;

            var role = new IdentityRole { Name = roleName };
            var result = await _roleManager.CreateAsync(role);

            if (!result.Succeeded) throw new Exception(string.Join("\n", result.Errors)); 
        }
    }
    private static async Task<ApplicationUser> AddAccountAsync(string email, string password)
    {
        var user = new ApplicationUser
        {
            UserName = email,
            Email = email,
            EmailConfirmed = true,
        };

        var result = await _userManager.CreateAsync(user, password);

        if (!result.Succeeded) throw new Exception(string.Join("\n", result.Errors));

        return user;
    }


}
