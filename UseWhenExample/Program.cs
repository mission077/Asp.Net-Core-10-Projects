var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.UseWhen(
    
    context => context.Request.Query.ContainsKey("username"),
    app =>
    {

        app.Use(async (context, next) =>
       {
           await context.Response.WriteAsync("Hello from the other side");
           await next(context);
       });

    }
    );

app.Run();
