
//////////////////////////////////////////////////////////////////////////////////////////////

//Order of the middleware//

using MiddlewareExample.CustomMiddleware;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddTransient<MyCustomMiddleware>();
var app = builder.Build();

app.UseExceptionHandler("/Error");
app.UseHsts();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseCors();
app.UseAuthentication();
app.UseAuthorization();
app.UseSession();
app.MapControllers();

//customMidlleware//

app.Use(async (HttpContext context, RequestDelegate next) => {

    if(context.Request.Query.ContainsKey("firstName"))
    {
        var name = context.Request.Query["firstName"];
        await context.Response.WriteAsync($"{name}");
        await next(context);
    }
});

///Endpoints//
app.Run(); 

////////////////////////////////////////////////////////////////////////////////////////