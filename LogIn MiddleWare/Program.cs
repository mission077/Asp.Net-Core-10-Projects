using Microsoft.AspNetCore.WebUtilities;
using LogIn_MiddleWare.CustomMiddleWare;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.UseMiddleware<Middleware>();

app.Run(async (context) => {
    if(context.Request.Path == "/" && context.Request.Method == "GET")
    {
        await context.Response.WriteAsync("No Response");
    }
});

app.Run();
