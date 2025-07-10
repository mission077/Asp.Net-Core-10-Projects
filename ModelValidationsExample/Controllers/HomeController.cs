using ModelValidationsExample.Models;
using Microsoft.AspNetCore.Mvc;

namespace ModelValidationsExample.Controllers;
public class HomeController : Controller
{
    [Route("register")]
    public IActionResult Index(Person _person)
    {
        return Content($"Person:{_person}");
    }
}
