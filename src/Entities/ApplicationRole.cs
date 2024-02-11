using Microsoft.AspNetCore.Identity;

namespace NextTime.Entities;

public sealed class ApplicationRole : IdentityRole<Guid>
{
    public ApplicationRole() { }

    public ApplicationRole(string name) : base(name) { }
}
