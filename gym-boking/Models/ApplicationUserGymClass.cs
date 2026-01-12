namespace gym_boking.Models;

public class ApplicationUserGymClass
{
    public string ApplicationUserId { get; set; } = null!;
    public ApplicationUser ApplicationUser { get; set; } = null!;

    public int GymClassId { get; set; }
    public GymClass GymClass { get; set; } = null!;
}
