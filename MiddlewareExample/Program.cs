using MiddlewareExample.CustomMiddleware;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddTransient<MyCustomMiddleware>();
var app = builder.Build();




//middlware 1
app.Use(async(HttpContext context, RequestDelegate next) => 
{
    await context.Response.WriteAsync("Hello from middleware 1 \n");
    await next(context);
});



//Before custom middleware 2 

//app.Use(async(HttpContext context, RequestDelegate next) => {

//    await context.Response.WriteAsync("My custom middleware 1");
//    await next(context);
//    await context.Response.WriteAsync("my custom middleware 2");
//});

//middleware class 
//app.UseMiddleware<MyCustomMiddleware>();


//app.UseMyCustomMiddleware(); //Middlware Extension


app.UseHelloCustomMiddleware();

//middleware 3
app.Run(async(HttpContext context) =>
{ 
    await context.Response.WriteAsync("From Middleware 3 \n");
});



app.Run();
