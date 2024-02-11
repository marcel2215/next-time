using Microsoft.AspNetCore.Identity;

namespace NextTime.Entities;

public sealed class ApplicationUser : IdentityUser<Guid>
{
    public ApplicationUser() : base() { }

    public ApplicationUser(string userName) : base(userName) { }

    public ICollection<Appointment> CreatedAppointments { get; } = [];

    public ICollection<Choice> Choices { get; } = [];
}
