using Microsoft.AspNetCore.Identity;

namespace gym_boking.Models;

public class ApplicationUser : IdentityUser
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string FullName => $"{FirstName} {LastName}";
    public ICollection<ApplicationUserGymClass> AttendedCalsses { get; set; } = new List<ApplicationUserGymClass>();
}
