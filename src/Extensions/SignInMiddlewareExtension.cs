using NextTime.Middleware;

namespace NextTime.Extensions;

public static class SignInMiddlewareExtension
{
    public static IApplicationBuilder UseSignInMiddleware(this IApplicationBuilder app)
    {
        return app.UseMiddleware<SignInMiddleware>();
    }
}
