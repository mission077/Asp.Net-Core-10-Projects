﻿
using System.Runtime.CompilerServices;

namespace MiddlewareExample.CustomMiddleware;

public class MyCustomMiddleware : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)            
    {
        await context.Response.WriteAsync("My Custom MiddleWare - Starts\n");
        await next(context);
        await context.Response.WriteAsync("My Custom MiddleWare - Ends\n");
    }
}

public static class CustomMiddlewareExtension
{
    public static IApplicationBuilder UseMyCustomMiddleware(this IApplicationBuilder app)
    {
        return app.UseMiddleware<MyCustomMiddleware>();
    }
}