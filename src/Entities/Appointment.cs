using System.Diagnostics.CodeAnalysis;

namespace NextTime.Entities;

public sealed class Appointment
{
    public Appointment() { }

    [SetsRequiredMembers]
    public Appointment(string title, string? description = null, string? location = null)
    {
        Title = title;
        Description = description;
        Location = location;
    }

    public Guid Id { get; init; } = Guid.NewGuid();

    public required string Title { get; set; }

    public string? Description { get; set; }

    public string? Location { get; set; }

    public DateTimeOffset CreationTime { get; init; } = DateTimeOffset.UtcNow;

    public DateTimeOffset NotBefore { get; set; } = DateTimeOffset.UtcNow;

    public DateTimeOffset NotAfter { get; set; } = DateTimeOffset.UtcNow.AddDays(30);

    public TimeSpan Duration { get; set; } = TimeSpan.FromHours(1);

    public ICollection<Choice> Choices { get; init; } = [];
}
