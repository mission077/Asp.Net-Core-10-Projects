using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Primitives;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.Run(async (HttpContext context) => {


    context.Response.Headers["Content-type"] = "text/html";
    if (context.Request.Method == "GET") 
    {
        bool hasfirst = context.Request.Query.ContainsKey("firstNumber");
        bool hassecond = context.Request.Query.ContainsKey("secondNumber");
        bool hasoperation = context.Request.Query.ContainsKey("operation");


           List<string> errorMessage = new List<string>();

            if (!hasfirst) errorMessage.Add("Invalid input for 'firstNumber ");
            if (!hassecond) errorMessage.Add("Invalid input for 'secondNumber ");
            if (!hasoperation || string.IsNullOrWhiteSpace(context.Request.Query["operation"]))
             {
            errorMessage.Add("Invalid input for 'operation'");
             }
        if (errorMessage.Count > 0)
        {
            context.Response.StatusCode = 400;
            await context.Response.WriteAsync(string.Join("\n", errorMessage));
            return;
        }

            int first = int.Parse(context.Request.Query["firstNumber"]);
            int second = int.Parse(context.Request.Query["secondNumber"]);
            string operands = context.Request.Query["operation"];

            int result = 0;
            switch (operands)
            {
                case "add":
                    result = first + second;
                    break;
                case "substraction":
                    result = first - second;
                    break;
                case "multiply":
                    result = first * second;
                    break;
                case "divide":
                    result = first / second;
                    break;
                case "modulus":
                    result = first % second;
                    break;

                default:

                    context.Response.StatusCode = 400;
                    await context.Response.WriteAsync("Invalid input for 'operation'");
                    return;
            }
            await context.Response.WriteAsync($"{result}");
        }            
});

app.Run();