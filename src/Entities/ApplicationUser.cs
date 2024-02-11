using Microsoft.AspNetCore.Identity;
using NextTime.Utilities;

namespace NextTime.Entities;

public sealed class ApplicationUser : IdentityUser<Guid>
{
    public ApplicationUser() : base(UserNameGenerator.GenerateUserName()) { }

    public ApplicationUser(string userName) : base(userName) { }

    public ICollection<Meeting> CreatedMeetings { get; } = [];

    public ICollection<Choice> Choices { get; } = [];
}
