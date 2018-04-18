using Microsoft.AspNetCore.Mvc;

namespace HelloAspNetCoreTagHelpers.Site.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}