using Microsoft.AspNetCore.WebUtilities;

namespace LogIn_MiddleWare.CustomMiddleWare;

public class Middleware
{
    private readonly RequestDelegate _next;

    public Middleware (RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        if (context.Request.Path == "/" && context.Request.Method == "POST")
        {
            var body = await new StreamReader(context.Request.Body).ReadToEndAsync();
            var parsed = QueryHelpers.ParseQuery(body);

            bool hasEmail = parsed.ContainsKey("email");
            bool hasPassword = parsed.ContainsKey("password");


            if (!hasEmail || !hasPassword)
            {
                context.Response.StatusCode = 400;
                if (!hasEmail)
                {
                    await context.Response.WriteAsync("Please enter your 'email'\n");
                }
                if (!hasPassword)
                {
                    await context.Response.WriteAsync("Please enter your 'password'");
                }
                return;
            }


            var email = parsed["email"];
            var password = parsed["password"];

            if (email == "admin@example.com" && password == "admin1234")
            {
                await context.Response.WriteAsync("Successful login!");
            }
            else
            {
                context.Response.StatusCode = 400;
                await context.Response.WriteAsync("Invalid login!");
            }

        }
        await _next(context);
    }
}

//public static class MiddlewareExtension
//{
//    public static IApplicationBuilder UseMiddlewareExtension(this IApplicationBuilder builder)
//    {
//        return builder.UseMiddleware<Middleware>();
//    }
//}