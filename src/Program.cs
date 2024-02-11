using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NextTime;
using NextTime.Components;
using NextTime.Constants;
using NextTime.Entities;
using NextTime.Extensions;
using NextTime.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(o => o.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddIdentity<ApplicationUser, ApplicationRole>().AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();
builder.Services.AddAuthentication();

builder.Services.AddAuthorizationBuilder()
    .AddPolicy(PolicyNames.Users, p => p.RequireRole(RoleNames.User, RoleNames.Admin))
    .AddPolicy(PolicyNames.Admins, p => p.RequireRole(RoleNames.Admin));

builder.Services.AddDatabaseSeeder();
builder.Services.AddRazorComponents().AddInteractiveServerComponents();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();
app.UseAuthentication();
app.UseAuthorization();
app.MapRazorComponents<App>().AddInteractiveServerRenderMode();

await using var databaseSeederScope = app.Services.CreateAsyncScope();
await databaseSeederScope.ServiceProvider.GetRequiredService<DatabaseSeeder>().SeedAllAsync();

app.Run();
