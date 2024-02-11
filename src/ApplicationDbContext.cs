using Microsoft.EntityFrameworkCore;
using NextTime.Entities;

namespace NextTime;

public sealed class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public required DbSet<Appointment> Appointments { get; init; }

    public required DbSet<Choice> Choices { get; init; }

    public required DbSet<Availability> Availabilities { get; init; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Appointment>().HasMany(a => a.Choices).WithOne(c => c.Appointment);
        modelBuilder.Entity<Choice>().HasMany(c => c.Availabilities).WithOne(a => a.Choice);
    }
}
