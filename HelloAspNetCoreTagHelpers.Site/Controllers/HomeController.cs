using HelloAspNetCoreTagHelpers.Site.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace HelloAspNetCoreTagHelpers.Site.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SlowToProcess()
        {
            return View();
        }

        public IActionResult ModelBound()
        {
            var model = new AddressVM
            {
                Line1 = "123 some road",
                Postcode = "AB12CD"
            };

            return View(model);
        }

        public IActionResult ViewContext()
        {
            var model = new LoginVM();

            ModelState.AddModelError("Username", "Simulated error"); // force the issue given nothing has actually been posted for this example

            return View(model);
        }
    }
}