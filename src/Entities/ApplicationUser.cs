using Microsoft.AspNetCore.Identity;
using NextTime.Utilities;

namespace NextTime.Entities;

public sealed class ApplicationUser : IdentityUser<Guid>
{
    public ApplicationUser() : base(RandomGenerator.GenerateUserName()) { }

    public ApplicationUser(string userName) : base(userName) { }

    public string? DisplayName { get; set; }

    public ICollection<Meeting> Meetings { get; } = [];

    public ICollection<Preference> Preferences { get; } = [];
}
