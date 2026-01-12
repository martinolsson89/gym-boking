using Microsoft.AspNetCore.Identity;

namespace gym_boking.Models;

public class ApplicationUser : IdentityUser
{
    public ICollection<ApplicationUserGymClass> AttendedCalsses { get; set; } = new List<ApplicationUserGymClass>();
}
