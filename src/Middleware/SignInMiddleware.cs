using Microsoft.AspNetCore.Identity;
using NextTime.Entities;
using NextTime.Services.Managers;

namespace NextTime.Middleware;

public sealed class SignInMiddleware(RequestDelegate next)
{
    public async Task InvokeAsync(HttpContext context, ApplicationUserManager userManager, SignInManager<ApplicationUser> signInManager)
    {
        if (context.User.Identity?.IsAuthenticated == true)
        {
            await next(context);
            return;
        }

        var user = new ApplicationUser();

        await userManager.CreateAsync(user);
        await signInManager.SignInAsync(user, true);
    }
}
