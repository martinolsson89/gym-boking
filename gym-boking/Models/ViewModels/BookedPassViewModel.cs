namespace gym_boking.Models.ViewModels;

public class BookedPassViewModel
{
    public string ApplicationUserId { get; set; } = null!;
    public string FullName { get; set; } = string.Empty;

    public List<GymClass> gymClasses { get; set; } = new();
}
