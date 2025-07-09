using Routing.CustomConstraints;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRouting(options =>
{
    options.ConstraintMap.Add("months", typeof(MonthsCustomConstraints));
});
var app = builder.Build();


//app.Use(async (context, next) => {

//    Endpoint ?endpoint =context.GetEndpoint();    //return the instance of endpoint type which represents an endpoint
//                                                  //two important properties: Display Name and Request Delegate
//    if(endpoint != null)
//    { 
//    await context.Response.WriteAsync($"Endpoint {endpoint.DisplayName}\n");
//    }
//    await next(context);
//});

app.UseRouting();//Enables routing and selects an appropriate end point based on the url path ad HTTP method

//app.Use(async (context, next) => {

//    Endpoint ?endpoint = context.GetEndpoint();

//    if(endpoint != null)
//    { 
//    await context.Response.WriteAsync($"Endpoint {endpoint.DisplayName}\n");
//    }
//    await next(context);
//});


app.UseEndpoints(endpoints =>
{

    //endpoints.MapPost();                       //Executes the appropriate endpoint based ont the endpoint selected by UseRouting method
    //endpoints.MapControllers();
    //endpoints.MapGet();

    //endpoints.MapGet("map1", async (context) =>
    //{

    //    await context.Response.WriteAsync("In Map 1");
    //});

    //endpoints.MapPost("map2", async (context) =>
    //{
    //    await context.Response.WriteAsync("In map 2");
    //});

    endpoints.Map("files/{filename}.{extension}", async (context) =>
    {
        string? fileName = Convert.ToString
         (context.Request.RouteValues["filename"]);

        string? extension = Convert.ToString
        (context.Request.RouteValues["extension"]);

        await context.Response.WriteAsync($"In files - {fileName} - {extension}");

    });


    //Eg: employee/profile/john
    endpoints.Map("employee/profile/{employeename:minlength(3)}", async (context) =>
    {

        string? employeename = Convert.ToString(context.Request.RouteValues["employeename"]);

        await context.Response.WriteAsync($"Our new employee is {employeename}");
    });



    //Eg. products/details/1

    endpoints.Map("products/details/{id:int?}", async (context) =>
    {

        int id = Convert.ToInt32(context.Request.RouteValues["id"]);

        await context.Response.WriteAsync($"Product details {id}");
    });


    //Eg: Daily Digest report/{reportdate?}

    endpoints.Map("daily-digest-report/{reportdate:datetime}", async (context) =>
    {
        DateTime reportDate=Convert.ToDateTime(context.Request.RouteValues["reportdate"]);

        await context.Response.WriteAsync($"The reported date is {reportDate.ToShortDateString()}");

    });

    //Eg: cities/cityid

    endpoints.Map("cities/{cityid:guid}", async (context) => {

        Guid cityId = Guid.Parse(Convert.ToString(context.Request.RouteValues["cityid"]));

        await context.Response.WriteAsync($"The given city id is {cityId}");
    });



    //sales-report/2023/apr
    endpoints.Map("sales-report/{year:int:minlength(1900)}/{month:regex(^(apr|jul|oct|jan)$)}", async (context) =>
    {

        int year = Convert.ToInt32(context.Request.RouteValues["year"]);
        string? month = Convert.ToString(context.Request.RouteValues["month"]);

        await context.Response.WriteAsync($"sales report - {year}-{month}");
    });


    //sales-report/2024/jan

    endpoints.Map("sales-report/2024/jan", async (context) =>
    {


        await context.Response.WriteAsync("Sales report for jan 2024");

    });



});

app.Run(async(context) => {
    await context.Response.WriteAsync($"Mo Route matched at {context.Request.Path}");

});
app.Run();
