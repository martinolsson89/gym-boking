namespace gym_boking.Models.ViewModels;

public sealed class GymClassDetailsViewModel
{
    public int Id { get; init; }
    public string Name { get; init; } = string.Empty;
    public DateTime StartTime { get; init; }
    public TimeSpan Duration { get; init; }
    public string Description { get; init; } = string.Empty;

    public IReadOnlyList<string> AttendeeEmails { get; init; } = Array.Empty<string>();
}