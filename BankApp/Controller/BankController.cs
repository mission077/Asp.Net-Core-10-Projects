using BankAppUsingController.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace BankAppUsingController.Controllers;

public class BankController : Controller
{
    [Route("/")]
    public IActionResult Home()
    {

        return Content("Welcome to the best bank", "text/plain");
    }

    [Route("/account-details")]
    public IActionResult AccountDetails()
    {
        Account account = new Account()
        {
            AccountNumber = 1001,
            AccountHolderName = "MissionKadariya",
            CurrentBalance = 1000000,

        };

        return Json(account);
    }

    [Route("/account-statement")]
    public IActionResult AccountStatement()
    {
        return File("/sample.pdf", "application/pdf");
    }

    [Route("/get-current-balance/{accountNumber:int?}")]
    public IActionResult GetCurrentBalance()
    {

        object accountNumberObj;
        if(!HttpContext.Request.RouteValues.TryGetValue("accountNumber", out accountNumberObj))
        {
            return NotFound("Account Number should be supplied");
        }

        if(!int.TryParse(accountNumberObj.ToString(), out int accnum))
        {
            return new BadRequestObjectResult("Invalid Account Number Format!");
        }

        Account account = new Account()
        {
            AccountNumber = 1001,
            AccountHolderName = "MissionKadariya",
            CurrentBalance = 100000,
        };

        if(!(accnum == account.AccountNumber))
        {
            return new BadRequestObjectResult("Account Number should be 1001");
        }

        return Content(account.CurrentBalance.ToString());

    }

}
