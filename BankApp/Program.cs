var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers(); // adds all the controller class which inheritates controller in the name
var app = builder.Build();

app.UseStaticFiles(); // adds all the static files
app.UseRouting(); // enables routing
app.MapControllers(); // adds all action method as endpoints

app.Run();
