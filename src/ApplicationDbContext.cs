using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NextTime.Entities;

namespace NextTime;

public sealed class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>(options)
{
    public required DbSet<Meeting> Meetings { get; init; }

    public required DbSet<Declaration> Declarations { get; init; }

    public required DbSet<Availability> Availabilities { get; init; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<ApplicationUser>().HasMany(u => u.CreatedMeetings).WithOne(a => a.Owner);
        modelBuilder.Entity<ApplicationUser>().HasMany(u => u.Declarations).WithOne(c => c.User);
        modelBuilder.Entity<Meeting>().HasMany(a => a.Declarations).WithOne(c => c.Meeting);
        modelBuilder.Entity<Declaration>().HasMany(c => c.Availabilities).WithOne(a => a.Declaration);
    }
}
