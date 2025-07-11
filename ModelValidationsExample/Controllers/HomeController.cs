using ModelValidationsExample.Models;
using Microsoft.AspNetCore.Mvc;

namespace ModelValidationsExample.Controllers;
public class HomeController : Controller
{
    [Route("register")]
    public IActionResult Index(Person _person)
    {
        if(ModelState.IsValid == false)
        {
            List<string> ErrorList = new List<string>();
            foreach (var values in ModelState.Values)
            {
                foreach (var error in values.Errors)
                {
                    ErrorList.Add(error.ErrorMessage);
                }
                string.Join("/n", ErrorList);
            }
            return BadRequest();
        }
        return Content($"Person:{_person}");
    }
}
