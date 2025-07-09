using Microsoft.AspNetCore.Mvc;
using ControllersExample.Models;
namespace ControllersExample.Controllers
{
    public class HomeController : Controller
    {
        [Route("Home")]        //One action method can have mutiple attribute route
        [Route("/")]          //Define the Route template this approach is called attribute routing
        public ContentResult Home()
        {
            return Content("Hello from the other side", "text/plain"); //Use this as a shorcut which inherits from the Controller parent class and Controller Base grandparent class

            //This is how you can return Content type
            //return new ContentResult() { Content = "Hello from the other side.", ContentType = "text/plain" };

            //return Content("<h1>Welcome</h1> " +
            //    "           <h2>Hellp from index</h2>", "text/html");

        }

        [Route("Index")]
        public string Index()
        {
            return "Welcome to the Index Page";
        }

        [Route("Contact-Us")]
        public string Contacts()
        {
            return "Welcome to the contacts";
            
        }

        [Route("person")]
        public JsonResult Person()  //class should be JsonResult if you use string or any other you cannot explicitly convert it to Json
        {
            Person person = new Person() 
            { 
                Id = Guid.NewGuid(), 
                FirstName = "james", 
                LastName = "Smith", 
                Age = 25 
            }; //Uses the model 

            return new JsonResult(person);  // returns the data in JsonFormat
        }

        [Route("file-download")]
        public VirtualFileResult fileDownload()
        {
            //return new VirtualFileResult("/sample.pdf", "application/pdf"); //return files from the wwwroot folder in the solution
            return File("/sample.pdf", "application/pdf"); //shortcut instead of new VirtualFileResult
            //if you pass file path and content type in the parameter then File method will return VirtualFileResult
        }

        [Route("file-download2")]
        public PhysicalFileResult fileDownload2()
        {
            // Specify both the file path and the content type as required by the PhysicalFileResult constructor
            ////returns the file from local directory 
            //return new PhysicalFileResult(@"C:\Users\mis8202\Desktop\Pay roll\March 2025\Earnings - Dayforce.pdf", "application/pdf");

            //shortcut for new PhysicalFileResult
            return PhysicalFile(@"C:\Users\mis8202\Desktop\Pay roll\March 2025\Earnings - Dayforce.pdf", "application/pdf");
        }
      
        [Route("file-download3")]
        public FileContentResult fileDownload3()
        {
            //Use it to smallers file like logo under 50MB
            byte[] bytes = System.IO.File.ReadAllBytes(@"C:\Users\mis8202\Desktop\Pay roll\March 2025\Earnings - Dayforce.pdf");

            //return new FileContentResult(bytes, "application/pdf"); //reads the file and return it into the byte format

            return File(bytes, "application/pdf"); //if you pass byte array as a parameter File method will return FileContentResult
        }

        [Route("file-download4")]
        public IActionResult filedownload4()  //IactionResult is the parent of all action result classes above so you can just use IActionResult as the return type for any one of the above classes
        {
            byte[] bytes = System.IO.File.ReadAllBytes(@"C:\Users\mis8202\Desktop\Pay roll\March 2025\Earnings - Dayforce.pdf");

            return File(bytes, "application/pdf"); 

        }



     

    }

    
}

