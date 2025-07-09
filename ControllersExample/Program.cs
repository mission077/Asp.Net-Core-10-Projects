

var builder = WebApplication.CreateBuilder(args);
//builder.Services.AddTransient<HomeController>();//Adding one controller
builder.Services.AddControllers(); // This one adds all the controller class which has the suffix controller

var app = builder.Build();
app.UseStaticFiles();


//app.UseRouting();   //optional to use UseRouting and UseEndpoints instead use MapControllers
//app.UseEndpoints(endpoints =>
//{
//    //endpoints.Map("/url", reference of the action method) // Adding routing to the single action method
//    endpoints.MapControllers(); // Enable routing for all the action method
//});

app.MapControllers(); // 



app.Run();
