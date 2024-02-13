using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NextTime.Entities;

namespace NextTime;

public sealed class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>(options)
{
    public required DbSet<Meeting> Meetings { get; init; }

    public required DbSet<Declaration> Declarations { get; init; }

    public required DbSet<Preference> Preferences { get; init; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<ApplicationUser>().HasMany(u => u.Meetings).WithOne(m => m.User).HasForeignKey(m => m.UserId);
        modelBuilder.Entity<ApplicationUser>().HasMany(u => u.Declarations).WithOne(d => d.User).HasForeignKey(d => d.UserId);
        modelBuilder.Entity<Meeting>().HasMany(m => m.Declarations).WithOne(d => d.Meeting).HasForeignKey(d => d.MeetingId);
        modelBuilder.Entity<Declaration>().HasMany(d => d.Preferences).WithOne(p => p.Declaration).HasForeignKey(p => p.DeclarationId);
    }
}
