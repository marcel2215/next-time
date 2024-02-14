using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NextTime.Entities;

namespace NextTime;

public sealed class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>(options)
{
    public required DbSet<Meeting> Meetings { get; init; }

    public required DbSet<Preference> Preferences { get; init; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<ApplicationUser>().HasMany(u => u.Meetings).WithOne(m => m.User).HasForeignKey(m => m.UserId);
        modelBuilder.Entity<ApplicationUser>().HasMany(u => u.Preferences).WithOne(p => p.User).HasForeignKey(p => p.UserId);
        modelBuilder.Entity<Meeting>().HasMany(m => m.Preferences).WithOne(p => p.Meeting).HasForeignKey(p => p.MeetingId);
    }
}
